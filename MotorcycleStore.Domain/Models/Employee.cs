using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MotorcycleStore.Domain.Models
{
    public class Employee
    {
        public int Id { get; set; }
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string Position { get; set; } = string.Empty;
        public string? Phone { get; set; }
        public string? Email { get; set; }
        public string Username { get; set; } = string.Empty;
        public string PasswordHash { get; set; } = string.Empty;
        public string Role { get; set; } = "Manager"; // "Admin" / "Manager"
        public DateTime HiredAt { get; set; } = DateTime.Now;
        public bool IsActive { get; set; } = true;
        public List<Order> Orders { get; set; } = new List<Order>();
    }
}
