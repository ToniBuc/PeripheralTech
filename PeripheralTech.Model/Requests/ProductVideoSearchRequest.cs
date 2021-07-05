using System;
using System.Collections.Generic;
using System.Text;

namespace PeripheralTech.Model.Requests
{
    public class ProductVideoSearchRequest
    {
        public int? ProductVideoID { get; set; }
        public int ProductID { get; set; }
    }
}
