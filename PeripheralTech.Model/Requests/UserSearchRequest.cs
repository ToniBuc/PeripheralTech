using System;
using System.Collections.Generic;
using System.Text;

namespace PeripheralTech.Model.Requests
{
    public class UserSearchRequest
    {
        public string UserName { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}
