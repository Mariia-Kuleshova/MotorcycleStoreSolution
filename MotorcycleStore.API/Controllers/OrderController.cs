using Microsoft.AspNetCore.Mvc;
using MotorcycleStore.API.Models;
using MotorcycleStore.Application.Interfaces;
using MotorcycleStore.Common;
using MotorcycleStore.Domain.Enums;
using MotorcycleStore.Domain.Models;

namespace MotorcycleStore.API.Controllers;

[ApiController]
[Route("api/orders")]
public class OrderController : ControllerBase
{
    private readonly IOrderService _orderService;
    private readonly ICustomerService _customerService;
    private readonly IEmployeeService _employeeService;
    private readonly IProductService _productService;
    private readonly IEmailService _emailService;
    private readonly IConfiguration _configuration;
    private readonly ILogger<OrderController> _logger;

    public OrderController(
        IOrderService orderService,
        ICustomerService customerService,
        IEmployeeService employeeService,
        IProductService productService,
        IEmailService emailService,
        IConfiguration configuration,
        ILogger<OrderController> logger)
    {
        _orderService = orderService;
        _customerService = customerService;
        _employeeService = employeeService;
        _productService = productService;
        _emailService = emailService;
        _configuration = configuration;
        _logger = logger;
    }

    [HttpPost]
    public async Task<ActionResult<object>> CreateFromWebsite([FromBody] CreateWebOrderRequest request)
    {
        if (request.ProductId <= 0)
            return BadRequest(new { message = "Оберіть мотоцикл." });

        if (string.IsNullOrWhiteSpace(request.CustomerName))
            return BadRequest(new { message = "Вкажіть ПІБ." });

        if (string.IsNullOrWhiteSpace(request.Phone))
            return BadRequest(new { message = "Вкажіть телефон." });

        var product = await _productService.GetByIdAsync(request.ProductId);
        if (product is null)
            return BadRequest(new { message = "Мотоцикл не знайдено." });

        if (!product.IsAvailable)
            return BadRequest(new { message = "Мотоцикл недоступний для замовлення." });

        if (product.Inventory is null || product.Inventory.Quantity < 1)
            return BadRequest(new { message = "Немає мотоцикла на складі." });

        var employeeId = await ResolveWebEmployeeIdAsync();
        if (employeeId is null)
            return StatusCode(500, new { message = "Неможливо оформити замовлення. Спробуйте пізніше." });

        var phone = request.Phone.Trim();
        var customer = await _customerService.GetByPhoneAsync(phone);
        if (customer is null)
        {
            var (firstName, lastName) = SplitCustomerName(request.CustomerName);
            customer = new Customer
            {
                FirstName = firstName,
                LastName = lastName,
                Phone = phone,
                Email = string.IsNullOrWhiteSpace(request.Email) ? null : request.Email.Trim()
            };
            await _customerService.AddAsync(customer);
        }
        else if (!string.IsNullOrWhiteSpace(request.Email) && string.IsNullOrWhiteSpace(customer.Email))
        {
            customer.Email = request.Email.Trim();
            await _customerService.UpdateAsync(customer);
        }

        var order = new Order
        {
            CustomerId = customer.Id,
            EmployeeId = employeeId.Value,
            Status = OrderStatus.Pending,
            PaymentMethod = WebOrderConstants.PaymentMethod,
            Comments = BuildComments(request.Comment),
            OrderItems = new List<OrderItem>
            {
                new()
                {
                    ProductId = product.Id,
                    Quantity = 1
                }
            }
        };

        try
        {
            await _orderService.CreateOrderAsync(order);
        }
        catch (Exception ex)
        {
            return BadRequest(new { message = ex.Message });
        }

        try
        {
            await _emailService.SendWebOrderNotificationAsync(
                order.Id,
                request.CustomerName.Trim(),
                phone,
                request.Email?.Trim(),
                product.Name,
                order.TotalAmount,
                request.Comment);
        }
        catch (Exception ex)
        {
            _logger.LogWarning(ex, "Не вдалося надіслати email про замовлення №{OrderId}.", order.Id);
        }

        return Ok(new
        {
            orderId = order.Id,
            message = "Заявку прийнято. Менеджер зв'яжеться з вами."
        });
    }

    private async Task<int?> ResolveWebEmployeeIdAsync()
    {
        var configuredId = _configuration.GetValue<int>("WebOrders:EmployeeId");
        if (configuredId > 0)
        {
            var employee = await _employeeService.GetByIdAsync(configuredId);
            if (employee is not null)
                return employee.Id;
        }

        var employees = await _employeeService.GetAllAsync();
        var active = employees.FirstOrDefault(e => e.IsActive);
        return active?.Id;
    }

    private static string? BuildComments(string? comment)
    {
        var text = comment?.Trim();
        if (string.IsNullOrEmpty(text))
            return "[WEB] Замовлення з сайту";

        return $"[WEB] {text}";
    }

    private static (string FirstName, string LastName) SplitCustomerName(string fullName)
    {
        var parts = fullName.Trim().Split(' ', 2, StringSplitOptions.RemoveEmptyEntries);
        if (parts.Length == 0)
            return ("Клієнт", "Сайт");

        if (parts.Length == 1)
            return (parts[0], "-");

        return (parts[0], parts[1]);
    }
}
