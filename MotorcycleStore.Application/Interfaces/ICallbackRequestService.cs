using MotorcycleStore.Domain.Models;

namespace MotorcycleStore.Application.Interfaces;

public interface ICallbackRequestService
{
    Task<IEnumerable<CallbackRequest>> GetAllAsync();
    Task<CallbackRequest> CreateAsync(CallbackRequest request);
    Task<bool> MarkProcessedAsync(int id);
}
