namespace MotorcycleStore.Domain.Models;

public class CallbackRequest
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Phone { get; set; } = string.Empty;
    public string? PreferredTime { get; set; }
    public string? Message { get; set; }
    public DateTime CreatedAt { get; set; } = DateTime.Now;
    public bool IsProcessed { get; set; }
}
