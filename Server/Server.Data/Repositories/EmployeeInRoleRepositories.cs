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
        public async Task<EmployeeInRole> AddPositionToEmployeeAsync(EmployeeInRole positionEmployee)
        {
            // בדיקה האם התפקיד כבר קיים בטבלה והשדה IsActive הוא false
            var existingPosition = await _context.EmployeeInRoles
                .FirstOrDefaultAsync(ep => ep.EmployeeId == positionEmployee.EmployeeId
                                          && ep.RoleId == positionEmployee.RoleId
                                          && ep.StatusActive == false);

            if (existingPosition != null)
            {
                // אם התפקיד כבר קיים והשדה IsActive הוא false, נשנה אותו לtrue
                existingPosition.StatusActive = true;
                var update = await UpdateRoleToEmployeeAsync(existingPosition.EmployeeId, existingPosition.RoleId, positionEmployee);
                await _context.SaveChangesAsync();
                return update;
            }

            await _context.EmployeeInRoles.AddAsync(positionEmployee);
            await _context.SaveChangesAsync();
            return positionEmployee;

        }

        public async Task<IEnumerable<EmployeeInRole>> GetEmployeeByIdAsync(int id)
        {
            return await _context.EmployeeInRoles.Where(e => e.EmployeeId == id).Where(r=>r.StatusActive)
            .Include(e => e.Role).Include(e => e.Employee).ToListAsync();



        }

        public async Task<EmployeeInRole> UpdateRoleToEmployeeAsync(int employeeId, int roleId, EmployeeInRole updatedEmployeeInRole)
        {
            var employeeInRole = await _context.EmployeeInRoles
            .FirstOrDefaultAsync(e => e.EmployeeId == employeeId && e.RoleId == roleId);

            if (employeeInRole == null)
            {
                return null;
            }

            // עדכן את פרטי התפקיד של העובד 
            employeeInRole.ManagerialPosition = updatedEmployeeInRole.ManagerialPosition;
            employeeInRole.DateOfStartingWork = updatedEmployeeInRole.DateOfStartingWork;

            // שמור את השינויים במסד הנתונים
            _context.EmployeeInRoles.Update(employeeInRole);
            await _context.SaveChangesAsync();

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
