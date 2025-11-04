using MotorcycleStore.Application.Interfaces;
using MotorcycleStore.Domain.Models;
using MotorcycleStore.Infrastructure.Repositories;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MotorcycleStore.Application.Services
{
    public class CustomerService : ICustomerService
    {
        private readonly CustomerRepository _repository;

        public CustomerService(CustomerRepository repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<Customer>> GetAllAsync()
        {
            return await _repository.GetAllAsync();
        }

        public async Task<Customer?> GetByIdAsync(int id)
        {
            return await _repository.GetByIdAsync(id);
        }

        public async Task AddAsync(Customer customer)
        {
            customer.RegisteredAt = System.DateTime.Now;
            await _repository.AddAsync(customer);
        }

        public async Task UpdateAsync(Customer customer)
        {
            await _repository.UpdateAsync(customer);
        }

        public async Task DeleteAsync(int id)
        {
            await _repository.DeleteAsync(id);
        }
    }
}

