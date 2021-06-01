using System;
using System.Collections.Generic;
using System.Text;

namespace PeripheralTech.Model.Requests
{
    public class OrderProductUpsertRequest
    {
        public int? OrderID { get; set; }
        public int? ProductID { get; set; }
    }
}
