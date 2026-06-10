using Microsoft.AspNetCore.Mvc;
using MotorcycleStore.API.Models;
using MotorcycleStore.Application.Interfaces;
using MotorcycleStore.Domain.Models;

namespace MotorcycleStore.API.Controllers;

[ApiController]
[Route("api/callbacks")]
public class CallbackController : ControllerBase
{
    private readonly ICallbackRequestService _callbackRequestService;

    public CallbackController(ICallbackRequestService callbackRequestService)
    {
        _callbackRequestService = callbackRequestService;
    }

    [HttpPost]
    public async Task<ActionResult<object>> Create([FromBody] CreateCallbackRequest request)
    {
        if (string.IsNullOrWhiteSpace(request.Name))
            return BadRequest(new { message = "Вкажіть ім'я." });

        if (string.IsNullOrWhiteSpace(request.Phone))
            return BadRequest(new { message = "Вкажіть телефон." });

        var callback = new CallbackRequest
        {
            Name = request.Name.Trim(),
            Phone = request.Phone.Trim(),
            PreferredTime = string.IsNullOrWhiteSpace(request.PreferredTime) ? null : request.PreferredTime.Trim(),
            Message = string.IsNullOrWhiteSpace(request.Message) ? null : request.Message.Trim()
        };

        await _callbackRequestService.CreateAsync(callback);

        return Ok(new
        {
            id = callback.Id,
            message = "Запит на дзвінок прийнято. Менеджер зв'яжеться з вами."
        });
    }
}
