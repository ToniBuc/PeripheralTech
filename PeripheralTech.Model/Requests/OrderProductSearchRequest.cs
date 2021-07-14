using System;
using System.Collections.Generic;
using System.Text;

namespace PeripheralTech.Model.Requests
{
    public class OrderProductSearchRequest
    {
        public int? OrderID { get; set; }
        public int? ProductID { get; set; }
        public bool MyOrdersCheck { get; set; }
        public bool CustomOrderProductsCheck { get; set; }
    }
}
