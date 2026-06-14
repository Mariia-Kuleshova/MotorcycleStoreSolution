using System.Net;
using System.Net.Mail;
using System.Text;
using Microsoft.Extensions.Logging;
using MotorcycleStore.Application.Interfaces;

namespace MotorcycleStore.API.Services;

public class SmtpEmailService : IEmailService
{
    private const string NotifyTo = "netanet508@gmail.com";

    private readonly IConfiguration _configuration;
    private readonly ILogger<SmtpEmailService> _logger;

    public SmtpEmailService(IConfiguration configuration, ILogger<SmtpEmailService> logger)
    {
        _configuration = configuration;
        _logger = logger;
    }

    public async Task SendWebOrderNotificationAsync(
        int orderId,
        string customerName,
        string phone,
        string? customerEmail,
        string productName,
        decimal totalAmount,
        string? comment)
    {
        var password = _configuration["Email:Password"];
        if (string.IsNullOrWhiteSpace(password))
        {
            _logger.LogWarning("Email:Password не налаштовано — лист про замовлення №{OrderId} не надіслано.", orderId);
            return;
        }

        var from = _configuration["Email:From"] ?? NotifyTo;
        var host = _configuration["Email:SmtpHost"] ?? "smtp.gmail.com";
        var port = _configuration.GetValue("Email:SmtpPort", 587);
        var username = _configuration["Email:Username"] ?? from;

        var subject = $"Підтвердження замовлення №{orderId} з сайту";
        var body = BuildBody(orderId, customerName, phone, customerEmail, productName, totalAmount, comment);

        using var message = new MailMessage(from, NotifyTo, subject, body)
        {
            BodyEncoding = Encoding.UTF8,
            SubjectEncoding = Encoding.UTF8,
            IsBodyHtml = false
        };

        using var client = new SmtpClient(host, port)
        {
            EnableSsl = true,
            Credentials = new NetworkCredential(username, password)
        };

        await client.SendMailAsync(message);
        _logger.LogInformation("Лист про замовлення №{OrderId} надіслано на {Email}.", orderId, NotifyTo);
    }

    private static string BuildBody(
        int orderId,
        string customerName,
        string phone,
        string? customerEmail,
        string productName,
        decimal totalAmount,
        string? comment)
    {
        var sb = new StringBuilder();
        sb.AppendLine("Вітаємо!");
        sb.AppendLine();
        sb.AppendLine($"Ваше замовлення №{orderId} прийнято.");
        sb.AppendLine();
        sb.AppendLine("Деталі замовлення:");
        sb.AppendLine($"  ПІБ: {customerName}");
        sb.AppendLine($"  Телефон: {phone}");
        sb.AppendLine($"  Email клієнта: {customerEmail ?? "не вказано"}");
        sb.AppendLine($"  Мотоцикл: {productName}");
        sb.AppendLine($"  Сума: {totalAmount:N2} грн");
        sb.AppendLine($"  Коментар: {(string.IsNullOrWhiteSpace(comment) ? "—" : comment.Trim())}");
        sb.AppendLine();
        sb.AppendLine("Менеджер зв'яжеться з вами найближчим часом.");
        sb.AppendLine();
        sb.AppendLine("Motorcycle Store");
        return sb.ToString();
    }
}
