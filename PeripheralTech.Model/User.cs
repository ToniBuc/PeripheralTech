using System;
using System.Collections.Generic;
using System.Text;

namespace PeripheralTech.Model
{
    public class User
    {
        public int UserID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Address { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public int UserRoleID { get; set; }
        public UserRole UserRole { get; set; }
        public string Username { get; set; }
        public string PasswordHash { get; set; }
        public string PasswordSalt { get; set; }
        public int? CityID { get; set; }
        public City City { get; set; }
        public byte[] ProfileImage { get; set; }
        //
        public string UserRoleName { get; set; }
        public string FullName { get; set; }
    }
}
