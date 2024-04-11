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
    public class RoleRepositories: IRoleRepositories
    {
        private readonly DataContext _context;
        public RoleRepositories(DataContext context)
        {
            _context = context;
        }
        public async Task<List<Role>> GetAllRolesAsync()
        {
            return await _context.Roles.ToListAsync();
        }

     public async   Task<Role> AddRoleAsync(Role role)
        {
            _context.Roles.Add(role);
            await _context.SaveChangesAsync();
            return role;
        }

      public async  Task<Role> UpdateRoleAsync(int id, Role role)
        {
            var existingRole = await _context.Roles.FindAsync(id);
            if (existingRole != null)
            {
                existingRole.Name = role.Name;
              
                await _context.SaveChangesAsync();
            }
            return existingRole;
        }

      public async  Task DeleteRoleAsync(int id)
        {
            var role = await _context.Roles.FindAsync(id);
            if (role != null)
            {
                _context.Roles.Remove(role);
                await _context.SaveChangesAsync();
            }
        }

    }
}
