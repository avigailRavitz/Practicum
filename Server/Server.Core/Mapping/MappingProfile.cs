using AutoMapper;
using Server.Core.DTOs;
using Server.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server.Core.Mapping
{
    public class MappingProfile: Profile
    {
        public MappingProfile()
        {

            CreateMap<Employee, EmployeeDTO>();
            CreateMap<EmployeeInRole, EmployeeInRoleDTO>();
            CreateMap<Role, RoleDTO>();

        }
    }
}
