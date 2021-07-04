using System;
using System.Collections.Generic;
using System.Text;

namespace PeripheralTech.Model
{
    public class OrderProduct
    {
        public int OrderProductID { get; set; }
        public int OrderID { get; set; }
        public Order Order { get; set; }
        public int ProductID { get; set; }
        public Product Product { get; set; }
        //
        public string ProductNameAndPrice { get; set; }
        public string ProductName { get; set; }
        public string ProductPrice { get; set; }
        public byte[] Thumbnail { get; set; }
        //for discounts
        public bool Discounted { get; set; }
        public string DiscountedString { get; set; }
        public decimal DiscountedPrice { get; set; }
    }
}
