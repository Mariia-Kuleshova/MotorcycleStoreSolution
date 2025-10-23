using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MotorcycleStore.Domain.Models
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; } = "";
        public string Brand { get; set; } = "";
        public string Category { get; set; } = "";
        public int ModelYear { get; set; }
        public decimal Price { get; set; }
        public string? Description { get; set; }
        public string? ImageUrl { get; set; }
        public bool IsAvailable { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public int SupplierId { get; set; }
        public Supplier Supplier { get; set; } = null!;
        public Inventory? Inventory { get; set; }
        public ICollection<OrderItem>? OrderItems { get; set; }
    }
}
