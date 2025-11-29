using MotorcycleStore.Domain.Enums;
using MotorcycleStore.Domain.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MotorcycleStore.Application.Interfaces
{
    public interface IOrderService
    {
        Task<IEnumerable<Order>> GetAllAsync();
        Task<Order?> GetByIdAsync(int id);
        Task<bool> CreateOrderAsync(Order order);
        Task<bool> UpdateStatusAsync(int orderId, OrderStatus newStatus);
        Task<decimal> CalculateTotalAsync(int orderId);
        Task DeleteAsync(int id);
    }
}

