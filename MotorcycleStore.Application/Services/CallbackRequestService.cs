using MotorcycleStore.Application.Interfaces;
using MotorcycleStore.Domain.Models;
using MotorcycleStore.Infrastructure.Repositories;

namespace MotorcycleStore.Application.Services;

public class CallbackRequestService : ICallbackRequestService
{
    private readonly CallbackRequestRepository _repository;

    public CallbackRequestService(CallbackRequestRepository repository)
    {
        _repository = repository;
    }

    public async Task<IEnumerable<CallbackRequest>> GetAllAsync()
    {
        return await _repository.GetAllAsync();
    }

    public async Task<CallbackRequest> CreateAsync(CallbackRequest request)
    {
        request.CreatedAt = DateTime.Now;
        request.IsProcessed = false;
        await _repository.AddAsync(request);
        return request;
    }

    public async Task<bool> MarkProcessedAsync(int id)
    {
        return await _repository.MarkProcessedAsync(id);
    }
}
