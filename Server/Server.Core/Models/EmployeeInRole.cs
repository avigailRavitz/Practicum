using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server.Core.Models
{
    public class EmployeeInRole
    {
        [Key]
        [Column(Order = 0)]
        [ForeignKey("Role")]
        public int RoleId { get; set; }

        [Key]
        [Column(Order = 1)]
        [ForeignKey("Employee")]
        public int EmployeeId { get; set; }

        public Role Role { get; set; }

        public Employee Employee { get; set; }

        public bool ManagerialPosition { get; set; }

        public DateTime DateOfStartingWork { get; set; }

        public bool StatusActive { get; set; }
        public EmployeeInRole()
        {
            StatusActive = true;
        }


    }
}
