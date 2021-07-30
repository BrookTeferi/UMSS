using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UMSS.Models
{
    public class UserRolesViewModel
    {
        public string UserId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public string EmployeeID { get; set; }
        public string PhoneNumber { get; set; }
        public byte[] ProfilePicture { get; set; }


        public IEnumerable<string> Roles { get; set; }
    }
}
