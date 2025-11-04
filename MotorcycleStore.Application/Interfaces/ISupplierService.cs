using MotorcycleStore.Domain.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MotorcycleStore.Application.Interfaces
{
    public interface ISupplierService
    {
        Task<IEnumerable<Supplier>> GetAllAsync();
        Task<Supplier?> GetByIdAsync(int id);
        Task AddAsync(Supplier supplier);
        Task UpdateAsync(Supplier supplier);
        Task DeleteAsync(int id);
    }
}

