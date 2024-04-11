using Server.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server.Core.Repositories
{
    public interface IEmployeeInRoleRepositories
    {
        Task<IEnumerable<EmployeeInRole>> GetEmployeeByIdAsync(int id);
        Task<EmployeeInRole> AddPositionToEmployeeAsync(EmployeeInRole employeeInRole);
        Task<EmployeeInRole> UpdateRoleToEmployeeAsync(int employeeId,int RoleId, EmployeeInRole employeeInRole);
        Task<bool> DeletRoleToEmployeeAsync(int employeeId, int positionId);
    }
}
