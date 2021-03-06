using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace PeripheralTech.Model.Requests
{
    public class UserInsertRequest
    {
        [Required(AllowEmptyStrings = false)]
        public string FirstName { get; set; }
        [Required(AllowEmptyStrings = false)]
        public string LastName { get; set; }
        //[Required]
        public string Address { get; set; }
        [Required]
        public string PhoneNumber { get; set; }
        [EmailAddress]
        [Required]
        [MinLength(5)]
        public string Email { get; set; }
        [Required]
        public int UserRoleID { get; set; }
        [Required(AllowEmptyStrings = false)]
        [MinLength(4)]
        public string Username { get; set; }
        [Required(AllowEmptyStrings = false)]
        [MinLength(8)]
        public string Password { get; set; }
        [Required(AllowEmptyStrings = false)]
        [MinLength(8)]
        public string PasswordConfirmation { get; set; }
        [Required]
        public int? CityID { get; set; }
        public byte[] ProfileImage { get; set; }
    }
}
