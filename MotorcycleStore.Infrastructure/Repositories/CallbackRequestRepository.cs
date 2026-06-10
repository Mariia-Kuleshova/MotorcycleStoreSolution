using Microsoft.EntityFrameworkCore;
using MotorcycleStore.Domain.Models;
using MotorcycleStore.Infrastructure.Data;

namespace MotorcycleStore.Infrastructure.Repositories;

public class CallbackRequestRepository
{
    private readonly IDbContextFactory<StoreDbContext> _contextFactory;

    public CallbackRequestRepository(IDbContextFactory<StoreDbContext> contextFactory)
    {
        _contextFactory = contextFactory;
    }

    public async Task<IEnumerable<CallbackRequest>> GetAllAsync()
    {
        using var context = _contextFactory.CreateDbContext();
        return await context.CallbackRequests
            .OrderByDescending(c => !c.IsProcessed)
            .ThenByDescending(c => c.CreatedAt)
            .ToListAsync();
    }

    public async Task<CallbackRequest?> GetByIdAsync(int id)
    {
        using var context = _contextFactory.CreateDbContext();
        return await context.CallbackRequests.FindAsync(id);
    }

    public async Task AddAsync(CallbackRequest request)
    {
        using var context = _contextFactory.CreateDbContext();
        context.CallbackRequests.Add(request);
        await context.SaveChangesAsync();
    }

    public async Task<bool> MarkProcessedAsync(int id)
    {
        using var context = _contextFactory.CreateDbContext();
        var request = await context.CallbackRequests.FindAsync(id);
        if (request is null)
            return false;

        request.IsProcessed = true;
        await context.SaveChangesAsync();
        return true;
    }
}
