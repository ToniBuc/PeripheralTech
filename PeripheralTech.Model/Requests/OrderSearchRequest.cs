using System;
using System.Collections.Generic;
using System.Text;

namespace PeripheralTech.Model.Requests
{
    public class OrderSearchRequest
    {
        //public string Username { get; set; }
        public int? UserID { get; set; }
        public string OrderStatus { get; set; }
    }
}
