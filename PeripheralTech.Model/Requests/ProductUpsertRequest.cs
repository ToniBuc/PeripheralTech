using System;
using System.Collections.Generic;
using System.Text;

namespace PeripheralTech.Model.Requests
{
    public class ProductUpsertRequest
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public int AmountInStock { get; set; }
        public int ProductTypeID { get; set; }
        public int CompanyID { get; set; }
        public byte[] Thumbnail { get; set; }
        public bool AvailableForCustom { get; set; }
    }
}
