using MotorcycleStore.Application.Interfaces;
using MotorcycleStore.Domain.Models;
using MotorcycleStore.Infrastructure.Repositories;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MotorcycleStore.Application.Services
{
    public class SupplierService : ISupplierService
    {
        private readonly SupplierRepository _repository;

        public SupplierService(SupplierRepository repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<Supplier>> GetAllAsync()
        {
            return await _repository.GetAllAsync();
        }

        public async Task<Supplier?> GetByIdAsync(int id)
        {
            return await _repository.GetByIdAsync(id);
        }

        public async Task AddAsync(Supplier supplier)
        {
            supplier.CreatedAt = System.DateTime.Now;
            supplier.IsActive = true;
            await _repository.AddAsync(supplier);
        }

        public async Task UpdateAsync(Supplier supplier)
        {
            await _repository.UpdateAsync(supplier);
        }

        public async Task DeleteAsync(int id)
        {
            await _repository.DeleteAsync(id);
        }
    }
}

