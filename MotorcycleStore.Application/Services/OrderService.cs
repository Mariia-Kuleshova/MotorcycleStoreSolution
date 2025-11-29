using MotorcycleStore.Application.Interfaces;
using MotorcycleStore.Domain.Enums;
using MotorcycleStore.Domain.Models;
using MotorcycleStore.Infrastructure.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MotorcycleStore.Application.Services
{
    public class OrderService : IOrderService
    {
        private readonly OrderRepository _orderRepository;
        private readonly ProductRepository _productRepository;
        private readonly InventoryRepository _inventoryRepository;

        public OrderService(
            OrderRepository orderRepository,
            ProductRepository productRepository,
            InventoryRepository inventoryRepository)
        {
            _orderRepository = orderRepository;
            _productRepository = productRepository;
            _inventoryRepository = inventoryRepository;
        }

        public async Task<IEnumerable<Order>> GetAllAsync()
        {
            return await _orderRepository.GetAllAsync();
        }

        public async Task<Order?> GetByIdAsync(int id)
        {
            return await _orderRepository.GetByIdAsync(id);
        }

        public async Task<bool> CreateOrderAsync(Order order)
        {
            if (order.OrderItems == null || !order.OrderItems.Any())
                throw new ArgumentException("Order must contain at least one item.");

            decimal total = 0m;

            foreach (var item in order.OrderItems)
            {
                var product = await _productRepository.GetByIdAsync(item.ProductId);
                if (product == null)
                    throw new Exception($"Product with ID {item.ProductId} not found.");

                var inventory = await _inventoryRepository.GetByProductIdAsync(product.Id);
                if (inventory == null || inventory.Quantity < item.Quantity)
                    throw new Exception($"Not enough stock for {product.Name}.");

                //зменшити кількість продукуту на складі
                inventory.Quantity -= item.Quantity;
                inventory.LastUpdated = DateTime.Now;
                await _inventoryRepository.UpdateAsync(inventory);

                //зафіксувати ціну на момент замовленн
                item.UnitPrice = product.Price;
                total += item.UnitPrice * item.Quantity;
            }

            order.TotalAmount = total;
            order.OrderDate = DateTime.Now;
            order.Status = OrderStatus.Pending;

            await _orderRepository.AddAsync(order);
            return true;
        }

        public async Task<bool> UpdateStatusAsync(int orderId, OrderStatus newStatus)
        {
            var order = await _orderRepository.GetByIdAsync(orderId);
            if (order == null) return false;

            order.Status = newStatus;
            await _orderRepository.UpdateAsync(order);
            return true;
        }

        public async Task<decimal> CalculateTotalAsync(int orderId)
        {
            var order = await _orderRepository.GetByIdAsync(orderId);
            if (order == null) throw new Exception("Order not found.");

            return order.OrderItems.Sum(i => i.Quantity * i.UnitPrice);
        }

        public async Task DeleteAsync(int id)
        {
            await _orderRepository.DeleteAsync(id);
        }
    }
}
