using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MotorcycleStore.Domain.Models
{
    public class Inventory
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        public int Quantity { get; set; }
        public string? Location { get; set; }
        public DateTime LastUpdated { get; set; } = DateTime.Now;
        public Product Product { get; set; } = null!;
    }
}
