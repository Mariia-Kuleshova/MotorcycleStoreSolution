using MotorcycleStore.Domain.Models;
using MotorcycleStore.Infrastructure.Repositories;
using System;
using System.Threading.Tasks;

namespace MotorcycleStore.Application.Services
{
    public class OrderItemService
    {
        private readonly ProductRepository _productRepository;
        private readonly InventoryRepository _inventoryRepository;

        public OrderItemService(ProductRepository productRepository, InventoryRepository inventoryRepository)
        {
            _productRepository = productRepository;
            _inventoryRepository = inventoryRepository;
        }

        public async Task<OrderItem> CreateOrderItemAsync(int productId, int quantity, decimal? priceOverride = null)
        {
            var product = await _productRepository.GetByIdAsync(productId);
            if (product == null)
                throw new ArgumentException("Продукт не найден");

            var inventory = await _inventoryRepository.GetByProductIdAsync(productId);
            if (inventory == null || inventory.Quantity < quantity)
                throw new InvalidOperationException("Недостаточно товара на складе");

            if (!product.IsAvailable)
                throw new InvalidOperationException("Продукт недоступен для заказа");

            var unitPrice = priceOverride ?? product.Price;

            inventory.Quantity -= quantity;
            inventory.LastUpdated = DateTime.Now;
            await _inventoryRepository.UpdateAsync(inventory);

            return new OrderItem
            {
                ProductId = productId,
                Quantity = quantity,
                UnitPrice = unitPrice,
                Product = product
            };
        }

        public async Task UpdateOrderItemAsync(OrderItem item, int newQuantity)
        {
            var inventory = await _inventoryRepository.GetByProductIdAsync(item.ProductId);
            if (inventory == null)
                throw new InvalidOperationException("Инвентарь не найден");

            int diff = newQuantity - item.Quantity;

            if (diff > 0)
            {
                if (inventory.Quantity < diff)
                    throw new InvalidOperationException("Недостаточно товара на складе");

                inventory.Quantity -= diff;
            }
            else
            {
                inventory.Quantity += Math.Abs(diff);
            }

            inventory.LastUpdated = DateTime.Now;
            await _inventoryRepository.UpdateAsync(inventory);

            item.Quantity = newQuantity;
        }

        public async Task RemoveOrderItemAsync(OrderItem item)
        {
            var inventory = await _inventoryRepository.GetByProductIdAsync(item.ProductId);
            if (inventory == null)
                throw new InvalidOperationException("Инвентарь не найден");

            inventory.Quantity += item.Quantity;
            inventory.LastUpdated = DateTime.Now;

            await _inventoryRepository.UpdateAsync(inventory);
        }
    }
}