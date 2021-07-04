using System;
using System.Collections.Generic;
using System.Text;

namespace PeripheralTech.Model.Requests
{
    public class OrderUpdateRequest
    {
        public int? OrderStatusID { get; set; }
        public string Comment { get; set; }
        public DateTime Date { get; set; }
    }
}
