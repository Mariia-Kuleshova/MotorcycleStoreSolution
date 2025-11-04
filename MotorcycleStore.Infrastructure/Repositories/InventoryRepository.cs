using MotorcycleStore.Domain.Models;
using MotorcycleStore.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MotorcycleStore.Infrastructure.Repositories
{
    public class InventoryRepository
    {
        private readonly StoreDbContext _context;

        public InventoryRepository(StoreDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Inventory>> GetAllAsync()
        {
            return await _context.Inventories
                .Include(i => i.Product)
                .ToListAsync();
        }

        public async Task<Inventory?> GetByIdAsync(int id)
        {
            return await _context.Inventories
                .Include(i => i.Product)
                .FirstOrDefaultAsync(i => i.Id == id);
        }

        public async Task<Inventory?> GetByProductIdAsync(int productId)
        {
            return await _context.Inventories
                .Include(i => i.Product)
                .FirstOrDefaultAsync(i => i.ProductId == productId);
        }

        public async Task AddAsync(Inventory inventory)
        {
            _context.Inventories.Add(inventory);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Inventory inventory)
        {
            _context.Inventories.Update(inventory);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var existing = await _context.Inventories.FindAsync(id);
            if (existing != null)
            {
                _context.Inventories.Remove(existing);
                await _context.SaveChangesAsync();
            }
        }
    }
}

