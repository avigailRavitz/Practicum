using Server.Core.Models;

namespace Server.Models
{
    public class EmployeeInRolePostModel
    {
        public int RoleId { get; set; }

        public bool ManagerialPosition { get; set; }
        public DateTime DateOfStartingWork { get; set; }
        //public Role Role { get; set; }
        

    }
}
