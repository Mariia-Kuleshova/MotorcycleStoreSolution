using MotorcycleStore.Application.Interfaces;
using MotorcycleStore.Domain.Models;
using MotorcycleStore.Infrastructure.Repositories;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MotorcycleStore.Application.Services
{
    public class InventoryService : IInventoryService
    {
        private readonly InventoryRepository _inventoryRepository;
        private readonly ProductRepository _productRepository;

        public InventoryService(InventoryRepository inventoryRepository, ProductRepository productRepository)
        {
            _inventoryRepository = inventoryRepository;
            _productRepository = productRepository;
        }

        public async Task<IEnumerable<Inventory>> GetAllAsync()
        {
            return await _inventoryRepository.GetAllAsync();
        }

        public async Task<Inventory?> GetByIdAsync(int id)
        {
            return await _inventoryRepository.GetByIdAsync(id);
        }

        public async Task<Inventory?> GetByProductIdAsync(int productId)
        {
            return await _inventoryRepository.GetByProductIdAsync(productId);
        }

        public async Task AddAsync(Inventory inventory)
        {
            inventory.LastUpdated = DateTime.Now;
            await _inventoryRepository.AddAsync(inventory);
        }

        public async Task UpdateAsync(Inventory inventory)
        {
            inventory.LastUpdated = DateTime.Now;
            await _inventoryRepository.UpdateAsync(inventory);
        }

        public async Task DeleteAsync(int id)
        {
            await _inventoryRepository.DeleteAsync(id);
        }

        public async Task<bool> UpdateQuantityAsync(int productId, int newQuantity)
        {
            var inventory = await _inventoryRepository.GetByProductIdAsync(productId);
            if (inventory == null)
                return false;

            inventory.Quantity = newQuantity;
            inventory.LastUpdated = DateTime.Now;
            await _inventoryRepository.UpdateAsync(inventory);
            return true;
        }

        public async Task<bool> AdjustQuantityAsync(int productId, int changeAmount)
        {
            var inventory = await _inventoryRepository.GetByProductIdAsync(productId);
            if (inventory == null)
                return false;

            int newQuantity = inventory.Quantity + changeAmount;
            if (newQuantity < 0)
                throw new InvalidOperationException("Cannot reduce quantity below zero.");

            inventory.Quantity = newQuantity;
            inventory.LastUpdated = DateTime.Now;
            await _inventoryRepository.UpdateAsync(inventory);
            return true;
        }
    }
}

