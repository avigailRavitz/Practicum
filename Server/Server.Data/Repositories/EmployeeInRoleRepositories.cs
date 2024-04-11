using Microsoft.EntityFrameworkCore;
using Server.Core.Models;
using Server.Core.Repositories;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server.Data.Repositories
{
    public class EmployeeInRoleRepositories : IEmployeeInRoleRepositories
    {
        private readonly DataContext _context;

        public EmployeeInRoleRepositories(DataContext context)
        {
            _context = context;
        }

        public async Task<EmployeeInRole> AddPositionToEmployeeAsync(EmployeeInRole employeeInRole)
        {
            await _context.EmployeeInRoles.AddAsync(employeeInRole);
            _context.SaveChanges();
            return employeeInRole;
        }
        public async Task<IEnumerable<EmployeeInRole>> GetEmployeeByIdAsync(int id)
        {
            return await _context.EmployeeInRoles.Where(e => e.EmployeeId == id).Where(r=>r.StatusActive)
            .Include(e => e.Role).Include(e => e.Employee).ToListAsync();



        }

        public async Task<EmployeeInRole> UpdateRoleToEmployeeAsync(int employeeId, int roleId, EmployeeInRole updatedEmployeeInRole)
        {
            // מצא את רשומת העובד בתפקיד במסד הנתונים
            var employeeInRole = await _context.EmployeeInRoles
            .FirstOrDefaultAsync(e => e.EmployeeId == employeeId && e.RoleId == roleId);

            // בדוק אם העובד קיים
            if (employeeInRole == null)
            {
                return null;
            }

            // עדכן את פרטי התפקיד של העובד לפי הפרטים שהוזנו
            employeeInRole.ManagerialPosition = updatedEmployeeInRole.ManagerialPosition;
            employeeInRole.DateOfStartingWork = updatedEmployeeInRole.DateOfStartingWork;

            // שמור את השינויים במסד הנתונים
            _context.EmployeeInRoles.Update(employeeInRole);
            await _context.SaveChangesAsync();

            // החזר את רשומת העובד בתפקיד לאחר העדכון
            return employeeInRole;
        }
        public async Task<bool> DeletRoleToEmployeeAsync(int employeeId, int roleId)
        {
            var roleEmployee = await _context.EmployeeInRoles.FirstOrDefaultAsync(e => e.EmployeeId == employeeId && e.RoleId == roleId);
            if (roleEmployee != null)
            {
                roleEmployee.StatusActive = false;
                await _context.SaveChangesAsync();
                return true;
            }
            return false;
        }

    }
}
