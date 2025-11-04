using MotorcycleStore.Domain.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MotorcycleStore.Application.Interfaces
{
    public interface IEmployeeService
    {
        Task<IEnumerable<Employee>> GetAllAsync();
        Task<Employee?> GetByIdAsync(int id);
        Task AddAsync(Employee employee);
        Task UpdateAsync(Employee employee);
        Task DeleteAsync(int id);

        //авторизаці
        Task<Employee?> GetByUsernameAsync(string username);
        Task<bool> ValidateCredentialsAsync(string username, string password);
    }
}

