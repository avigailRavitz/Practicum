using Microsoft.EntityFrameworkCore;
using Server.Core.Models;
using Server.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server.Data.Repositories
{
    public class EmployeeRepositories : IEmployeeRepositories

    {
        private readonly DataContext _context;

        public EmployeeRepositories(DataContext context)
        {
            _context = context;
        }
        public async Task<List<Employee>> GetEmployeesAsync()
        {
            return await _context.Employees.ToListAsync();

        }
        public async Task<Employee> GetEmployeeByIdAsync(int id)
        {
            var employee = await _context.Employees.FindAsync(id);
            return employee;
        }
        public async Task<Employee> AddEmployeeAsync(Employee employee)
        {
            _context.Employees.Add(employee);
            await _context.SaveChangesAsync();
            return employee;
        }

        //public async Task DeleteEmployeeAsync(int id)
        //{
        //    var temp = await _context.Employees.FirstOrDefaultAsync(x => x.Id == id);
        //    temp.StatusActive = false;
        //    await _context.SaveChangesAsync();

        //}
        public async Task DeleteEmployeeAsync(int employeeId)
        {
            var employee = await _context.Employees.FirstOrDefaultAsync(e => e.EmployeeId == employeeId);

            if (employee != null)
            {

                employee.StatusActive = false;
                await _context.SaveChangesAsync();

            }


        }

        public async Task<Employee> UpdateEmployeeAsync(int id, Employee employee)
        {
            var temp = _context.Employees.Find(id);
            if (temp != null)
            {
                temp.EmployeeId = employee.EmployeeId;
                temp.FirstName = employee.FirstName;
                temp.LastName = employee.LastName;
                temp.Birthday = employee.Birthday;
                temp.Gender = employee.Gender;
                temp.DateStart = employee.DateStart;
            }

            await _context.SaveChangesAsync();
            return employee;
        }

    }
}
