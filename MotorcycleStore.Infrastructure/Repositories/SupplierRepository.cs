using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;
using MotorcycleStore.Domain.Models;
using MotorcycleStore.Infrastructure.Data;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MotorcycleStore.Infrastructure.Repositories
{
    public class SupplierRepository
    {
        private readonly IDbContextFactory<StoreDbContext> _contextFactory;

        public SupplierRepository(IDbContextFactory<StoreDbContext> contextFactory)
        {
            _contextFactory = contextFactory;
        }

        public async Task<IEnumerable<Supplier>> GetAllAsync()
        {
            using var _context = _contextFactory.CreateDbContext();
            return await _context.Suppliers
                .ToListAsync();
        }

        public async Task<Supplier?> GetByIdAsync(int id)
        {
            using var _context = _contextFactory.CreateDbContext();
            return await _context.Suppliers
                .FirstOrDefaultAsync(s => s.Id == id);
        }

        public async Task AddAsync(Supplier supplier)
        {
            using var _context = _contextFactory.CreateDbContext();
            _context.Suppliers.Add(supplier);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Supplier supplier)
        {
            using var _context = _contextFactory.CreateDbContext();
            _context.Suppliers.Update(supplier);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            using var _context = _contextFactory.CreateDbContext();
            var supplier = await _context.Suppliers.FindAsync(id);
            if (supplier != null)
            {
                _context.Suppliers.Remove(supplier);
                await _context.SaveChangesAsync();
            }
        }
    }
}

