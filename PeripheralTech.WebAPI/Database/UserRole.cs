using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PeripheralTech.WebAPI.Database
{
    public class UserRole
    {
        public int UserRoleID { get; set; }
        public string Name { get; set; }
        public string? Description { get; set; }
    }
}
