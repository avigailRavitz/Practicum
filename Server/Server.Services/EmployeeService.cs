using Server.Core.Models;
using Server.Core.Repositories;
using Server.Core.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

 namespace Server.Services
{
    public class EmployeeService:IEmployeeServices
    {
        private readonly IEmployeeRepositories _employeeRepositories;
        public EmployeeService(IEmployeeRepositories employeeRepositories)
        {
            _employeeRepositories = employeeRepositories;
        }

        public async Task<List<Employee>> GetEmployeesAsync()
        {
            return await _employeeRepositories.GetEmployeesAsync();
        }
        public async Task<Employee> GetEmployeeByIdAsync(int id)
        {
            return await _employeeRepositories.GetEmployeeByIdAsync(id);
        }
        public async Task<Employee> AddEmployeeAsync(Employee employee)
        {
            return await _employeeRepositories.AddEmployeeAsync(employee);
        }

        public async Task<Employee> UpdateEmployeeAsync(int id,Employee employee)
        {
            return await _employeeRepositories.UpdateEmployeeAsync(id, employee);
        }

        public async Task DeleteEmployeeAsync(int id)
        {
            await _employeeRepositories.DeleteEmployeeAsync(id);
        }
    }
}
