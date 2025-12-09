using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;
using MotorcycleStore.Domain.Models;
using MotorcycleStore.Infrastructure.Data;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MotorcycleStore.Infrastructure.Repositories
{
    public class ProductRepository
    {       
        private readonly InventoryRepository _inventoryRepository;
        private readonly IDbContextFactory<StoreDbContext> _contextFactory;

        public ProductRepository(IDbContextFactory<StoreDbContext> contextFactory, InventoryRepository inventoryRepository)
        {
            _contextFactory = contextFactory;
            _inventoryRepository = inventoryRepository;
        }

        public async Task<IEnumerable<Product>> GetAllAsync()
        {
            using var _context = _contextFactory.CreateDbContext();
            return await _context.Products
             .Include(p => p.Inventory) 
             .ToListAsync();
        }

        public async Task<Product> GetByIdAsync(int id)
        {
            using var _context = _contextFactory.CreateDbContext();
            return await _context.Products
            .Include(p => p.Inventory) 
            .FirstOrDefaultAsync(p => p.Id == id);
        }

        public async Task AddAsync(ProductDTO product)
        {
            using var _context = _contextFactory.CreateDbContext();
            _context.Products.Add(product.Product);
            await _context.SaveChangesAsync();

            var inventory = new Inventory
            {
                ProductId = product.Product.Id, 
                Quantity = product.Qty
            };

            await _inventoryRepository.AddAsync(inventory);
        }

        public async Task UpdateAsync(Product product, int qty)
        {
            using var _context = _contextFactory.CreateDbContext();
            _context.Products.Update(product);
            var prod = _context.Inventories.FirstOrDefault(p => p.ProductId == product.Id);
            if (prod != null) 
            { 
                prod.Quantity = qty;
            }
            else
            {
                var inventory = new Inventory
                {
                    ProductId = product.Id,
                    Quantity = qty
                };

                await _inventoryRepository.AddAsync(inventory);
            }
                await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            using var _context = _contextFactory.CreateDbContext();
            var product = await GetByIdAsync(id);
            if (product != null)
            {
                var relatedOrderItems = _context.OrderItems.Where(oi => oi.ProductId == id);
                _context.OrderItems.RemoveRange(relatedOrderItems);

                _context.Products.Remove(product);
                await _context.SaveChangesAsync();
            }
        }
    }
}
