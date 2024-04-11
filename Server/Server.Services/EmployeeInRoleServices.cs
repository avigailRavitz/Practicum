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
    public class EmployeeInRoleServices : IEmployeeInRoleServices
    {

        private readonly IEmployeeInRoleRepositories _employeeInRoleRepositories;

        
        public EmployeeInRoleServices(IEmployeeInRoleRepositories employeeInRoleRepositories)
        {
            _employeeInRoleRepositories = employeeInRoleRepositories;
        }

        public async Task<IEnumerable<EmployeeInRole>> GetEmployeeInRoleByIdAsync(int employeeId)
        {
            return await _employeeInRoleRepositories.GetEmployeeByIdAsync(employeeId);
        }
        public async Task<EmployeeInRole> AddPositionToEmployeeAsync(int EmployeeId, EmployeeInRole employeeInRole)
        {
            employeeInRole.EmployeeId = EmployeeId;

            return await _employeeInRoleRepositories.AddPositionToEmployeeAsync(employeeInRole);
        }
        public async Task<EmployeeInRole> UpdateRoleToEmployeeAsync(int employeeId, int positionId, EmployeeInRole employeeInRole)
        {
            return await _employeeInRoleRepositories.UpdateRoleToEmployeeAsync(employeeId, positionId, employeeInRole);
        }

        public async Task<bool> DeletRoleToEmployeeAsync(int employeeId, int RoleId)
        {
            return await _employeeInRoleRepositories.DeletRoleToEmployeeAsync(employeeId, RoleId);
        }
    }
}
