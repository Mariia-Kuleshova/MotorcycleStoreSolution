using MotorcycleStore.Application.Interfaces;
using MotorcycleStore.Domain.Models;
using MotorcycleStore.Infrastructure.Repositories;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MotorcycleStore.Application.Services
{
    public class ProductService : IProductService
    {
        private readonly ProductRepository _repository;

        public ProductService(ProductRepository repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<Product>> GetAllAsync()
        {
            return await _repository.GetAllAsync();
        }

        public async Task<Product> GetByIdAsync(int id)
        {
            return await _repository.GetByIdAsync(id);
        }

        public async Task AddAsync(ProductDTO product)
        {
            await _repository.AddAsync(product);
        }

        public async Task UpdateAsync(Product product, int q)
        {
            await _repository.UpdateAsync(product, q);
        }

        public async Task DeleteAsync(int id)
        {
            await _repository.DeleteAsync(id);
        }
    }
}

