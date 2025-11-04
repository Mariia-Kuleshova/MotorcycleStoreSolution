using MotorcycleStore.Domain.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MotorcycleStore.Application.Interfaces
{
    public interface IInventoryService
    {
        Task<IEnumerable<Inventory>> GetAllAsync();
        Task<Inventory?> GetByIdAsync(int id);
        Task<Inventory?> GetByProductIdAsync(int productId);
        Task AddAsync(Inventory inventory);
        Task UpdateAsync(Inventory inventory);
        Task DeleteAsync(int id);
        Task<bool> UpdateQuantityAsync(int productId, int newQuantity);
        Task<bool> AdjustQuantityAsync(int productId, int changeAmount);
    }
}

