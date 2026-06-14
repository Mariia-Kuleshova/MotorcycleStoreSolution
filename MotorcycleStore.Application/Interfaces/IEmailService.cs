namespace MotorcycleStore.Application.Interfaces;

public interface IEmailService
{
    Task SendWebOrderNotificationAsync(
        int orderId,
        string customerName,
        string phone,
        string? customerEmail,
        string productName,
        decimal totalAmount,
        string? comment);
}
