using MotorcycleStore.Domain.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MotorcycleStore.Application.Interfaces
{
    public interface IProductService
    {
        Task<IEnumerable<Product>> GetAllAsync();
        Task<Product> GetByIdAsync(int id);
        Task AddAsync(ProductDTO product);
        Task UpdateAsync(Product product, int qty);
        Task DeleteAsync(int id);
    }
}

