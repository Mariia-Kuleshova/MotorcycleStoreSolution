using MotorcycleStore.Domain.Models;
using MotorcycleStore.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MotorcycleStore.Infrastructure.Repositories
{
    public class CustomerRepository
    {
        private readonly IDbContextFactory<StoreDbContext> _contextFactory;

        public CustomerRepository(IDbContextFactory<StoreDbContext> contextFactory)
        {
            _contextFactory = contextFactory;
        }

        public async Task<IEnumerable<Customer>> GetAllAsync()
        {
            using var _context = _contextFactory.CreateDbContext();
            return await _context.Customers
                .Include(c => c.Orders)
                .ToListAsync();
        }

        public async Task<Customer?> GetByIdAsync(int id)
        {
            using var _context = _contextFactory.CreateDbContext();
            return await _context.Customers
                .Include(c => c.Orders)
                .FirstOrDefaultAsync(c => c.Id == id);
        }

        public async Task AddAsync(Customer customer)
        {
            using var _context = _contextFactory.CreateDbContext();
            _context.Customers.Add(customer);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Customer customer)
        {
            using var _context = _contextFactory.CreateDbContext();
            _context.Customers.Update(customer);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            using var _context = _contextFactory.CreateDbContext();
            var existing = await _context.Customers
                .Include(c => c.Orders)
                .FirstOrDefaultAsync(c => c.Id == id);

            if (existing != null)
            {
                _context.Orders.RemoveRange(existing.Orders);
                _context.Customers.Remove(existing);
                await _context.SaveChangesAsync();
            }
        }
    }
}

