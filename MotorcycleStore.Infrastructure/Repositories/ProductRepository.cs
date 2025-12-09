using MotorcycleStore.Domain.Models;
using MotorcycleStore.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MotorcycleStore.Infrastructure.Repositories
{
    public class ProductRepository
    {
        private readonly StoreDbContext _context;
        private readonly InventoryRepository _inventoryRepository;

        public ProductRepository(StoreDbContext context, InventoryRepository inventoryRepository)
        {
            _context = context;
            _inventoryRepository = inventoryRepository;
        }

        public async Task<IEnumerable<Product>> GetAllAsync()
        {
            return await _context.Products
             .Include(p => p.Inventory) 
             .ToListAsync();
        }

        public async Task<Product> GetByIdAsync(int id)
        {
            return await _context.Products
            .Include(p => p.Inventory) 
            .FirstOrDefaultAsync(p => p.Id == id);
        }

        public async Task AddAsync(ProductDTO product)
        {
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
            var product = await GetByIdAsync(id);
            if (product != null)
            {
                _context.Products.Remove(product);
                await _context.SaveChangesAsync();
            }
        }
    }
}
