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
    public class RoleServices : IRoleServices
    {
        private readonly  IRoleRepositories _roleRepository;
        public RoleServices(IRoleRepositories roleRepositories)
        {
            _roleRepository = roleRepositories;
        }
        public async Task<Role> AddRoleAsync(Role role)
        {
            return await _roleRepository.AddRoleAsync(role);
        }

        public async Task DeleteRoleAsync(int id)
        {
            await _roleRepository.DeleteRoleAsync(id);  
        }

        public async Task<List<Role>> GetAllRolesAsync()
        {
           return await _roleRepository.GetAllRolesAsync();
        }



        public async Task<Role> UpdateRoleAsync(int id, Role role)
        {
            return await _roleRepository.UpdateRoleAsync(id, role); 
        }
    }
}
