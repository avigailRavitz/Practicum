using Server.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server.Core.DTOs
{
    public class EmployeeDTO
    {

        public int EmployeeId { get; set; }
        public string Identity { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime DateStart { get; set; }
        public DateTime Birthday { get; set; }
        public Gender Gender { get; set; }
        public bool StatusActive { get; set; }



    }
}
