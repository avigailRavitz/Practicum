using Server.Core.Models;

namespace Server.Models
{
    public class EmployeePostModel
    {
        public string Identity { get; set; }
        
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime DateStart { get; set; }
        public DateTime Birthday { get; set; }
        public Gender Gender { get; set; }

    }
}
