namespace MotorcycleStore.API.Models;

public class CreateWebOrderRequest
{
    public int ProductId { get; set; }
    public string CustomerName { get; set; } = string.Empty;
    public string Phone { get; set; } = string.Empty;
    public string? Email { get; set; }
    public string? Comment { get; set; }
}
