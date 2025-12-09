using MotorcycleStore.Domain.Models;
using MotorcycleStore.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MotorcycleStore.Infrastructure.Repositories
{
    public class InventoryRepository
    {
        private readonly IDbContextFactory<StoreDbContext> _contextFactory;

        public InventoryRepository(IDbContextFactory<StoreDbContext> contextFactory)
        {
            _contextFactory = contextFactory;
        }

        public async Task<IEnumerable<Inventory>> GetAllAsync()
        {
            using var _context = _contextFactory.CreateDbContext();
            return await _context.Inventories
                .Include(i => i.Product)
                .ToListAsync();
        }

        public async Task<Inventory?> GetByIdAsync(int id)
        {
            using var _context = _contextFactory.CreateDbContext();
            return await _context.Inventories
                .Include(i => i.Product)
                .FirstOrDefaultAsync(i => i.Id == id);
        }

        public async Task<Inventory?> GetByProductIdAsync(int productId)
        {
            using var _context = _contextFactory.CreateDbContext();
            return await _context.Inventories
                .Include(i => i.Product)
                .FirstOrDefaultAsync(i => i.ProductId == productId);
        }

        public async Task AddAsync(Inventory inventory)
        {
            using var _context = _contextFactory.CreateDbContext();
            inventory.LastUpdated = DateTime.Now;
            _context.Inventories.Add(inventory);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Inventory inventory)
        {
            using var _context = _contextFactory.CreateDbContext();
            _context.Inventories.Update(inventory);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            using var _context = _contextFactory.CreateDbContext();
            var existing = await _context.Inventories.FindAsync(id);
            if (existing != null)
            {
                _context.Inventories.Remove(existing);
                await _context.SaveChangesAsync();
            }
        }
    }
}

