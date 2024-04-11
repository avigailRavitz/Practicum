using Server.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server.Core.Services
{
    public interface IEmployeeServices
    {
        Task<List<Employee>> GetEmployeesAsync();
        Task<Employee> GetEmployeeByIdAsync(int id);
        Task<Employee> AddEmployeeAsync(Employee Employee);
        Task<Employee> UpdateEmployeeAsync(int id, Employee employee);
        Task DeleteEmployeeAsync(int id);
    }
}
