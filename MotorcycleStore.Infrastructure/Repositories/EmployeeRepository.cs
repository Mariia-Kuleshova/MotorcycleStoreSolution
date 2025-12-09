using MotorcycleStore.Domain.Models;
using MotorcycleStore.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MotorcycleStore.Infrastructure.Repositories
{
    public class EmployeeRepository
    {
        private readonly IDbContextFactory<StoreDbContext> _contextFactory;

        public EmployeeRepository(IDbContextFactory<StoreDbContext> contextFactory)
        {
            _contextFactory = contextFactory;
        }

        public async Task<IEnumerable<Employee>> GetAllAsync()
        {

            using var _context = _contextFactory.CreateDbContext();
            return await _context.Employees
                .Include(e => e.Orders)
                .ToListAsync();
        }

        public async Task<Employee?> GetByIdAsync(int id)
        {
            using var _context = _contextFactory.CreateDbContext();
            return await _context.Employees
                .Include(e => e.Orders)
                .FirstOrDefaultAsync(e => e.Id == id);
        }

        public async Task AddAsync(Employee employee)
        {
            using var _context = _contextFactory.CreateDbContext();
            _context.Employees.Add(employee);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Employee employee)
        {
            using var _context = _contextFactory.CreateDbContext();
            _context.Employees.Update(employee);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            using var _context = _contextFactory.CreateDbContext();
            var existing = await _context.Employees.FindAsync(id);
            if (existing != null)
            {
                _context.Employees.Remove(existing);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<Employee?> GetByUsernameAsync(string username)
        {
            using var _context = _contextFactory.CreateDbContext();
            return await _context.Employees.FirstOrDefaultAsync(e => e.Username == username);
        }
    }
}

