using System;
using System.Collections.Generic;
using System.Text;

namespace PeripheralTech.Model.Requests
{
    public class ProductSearchRequest
    {
        public string ProductName { get; set; }
        public int? ProductTypeID { get; set; }
        public int? CompanyID { get; set; }
        public string OrderByPrice { get; set; }
        public string InStock { get; set; }
    }
}
