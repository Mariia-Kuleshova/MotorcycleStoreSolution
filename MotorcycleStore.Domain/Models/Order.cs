using MotorcycleStore.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MotorcycleStore.Domain.Models
{
    public class Order
    {
        public int Id { get; set; }
        public int CustomerId { get; set; }
        public int EmployeeId { get; set; }
        public DateTime OrderDate { get; set; } = DateTime.Now;
        public OrderStatus Status { get; set; } = OrderStatus.Pending;
        public decimal TotalAmount { get; set; }
        public string PaymentMethod { get; set; } = "Cash"; // cash, card, transfer
        public string? Comments { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public Customer Customer { get; set; } = null!;
        public Employee Employee { get; set; } = null!;
        public List<OrderItem> OrderItems { get; set; } = new List<OrderItem>();
    }
}
