﻿using Server.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server.Core.Services
{
    public interface IRoleServices
    {
        Task<List<Role>> GetAllRolesAsync();

        Task<Role> AddRoleAsync(Role role);

        Task<Role> UpdateRoleAsync(int id, Role role);

        Task DeleteRoleAsync(int id);
    }
}
