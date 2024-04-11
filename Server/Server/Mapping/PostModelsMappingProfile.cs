using AutoMapper;
using Server.Core.Models;
using Server.Models;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Server.Mapping
{
    public class PostModelsMappingProfile: Profile
    {
        public PostModelsMappingProfile()
        {
            CreateMap<EmployeePostModel, Employee>().ReverseMap();
            CreateMap<EmployeeInRolePostModel, EmployeeInRole>();
            CreateMap<RolePostModel, Role>();
        }
    }
}
