using Server.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server.Core.Services
{
    public interface IEmployeeInRoleServices
    {

        Task<IEnumerable<EmployeeInRole>> GetEmployeeInRoleByIdAsync(int employeeId);
        Task<EmployeeInRole> AddPositionToEmployeeAsync(int EmployeeId, EmployeeInRole positionEmployee);
        Task<EmployeeInRole> UpdateRoleToEmployeeAsync(int employeeId, int roleId, EmployeeInRole employeeInRole);
        Task<bool> DeletRoleToEmployeeAsync(int employeeId, int positionId);

    }
}
