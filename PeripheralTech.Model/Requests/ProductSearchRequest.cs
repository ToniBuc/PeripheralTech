using System;
using System.Collections.Generic;
using System.Text;

namespace PeripheralTech.Model.Requests
{
    public class ProductSearchRequest
    {
        public int? ProductID { get; set; }
        public string ProductName { get; set; }
        public int? ProductTypeID { get; set; }
        public int? CompanyID { get; set; }
        public string OrderByPrice { get; set; }
        public string InStock { get; set; }
        public int? AmountInStock { get; set; }
        //
        public bool AvailableForCustom { get; set; }
    }
}
