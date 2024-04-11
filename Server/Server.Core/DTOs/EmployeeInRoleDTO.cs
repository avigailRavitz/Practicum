using Server.Core.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server.Core.DTOs
{
    public class EmployeeInRoleDTO
    {
        public int RoleId { get; set; }
        public int EmployeeId { get; set; }
        public bool StatusActive { get; set; }
        //public Role Role { get; set; }
        //public Employee Employee { get; set; }
        //public bool ManagerialPosition { get; set; }
        //public DateTime DateOfStartingWork { get; set; }
    }
}
