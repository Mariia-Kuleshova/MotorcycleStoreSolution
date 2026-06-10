namespace MotorcycleStore.API.Models;

public class CreateCallbackRequest
{
    public string Name { get; set; } = string.Empty;
    public string Phone { get; set; } = string.Empty;
    public string? PreferredTime { get; set; }
    public string? Message { get; set; }
}
