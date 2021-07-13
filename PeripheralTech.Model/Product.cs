using System;
using System.Collections.Generic;
using System.Text;

namespace PeripheralTech.Model
{
    public class Product
    {
        public int ProductID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public int AmountInStock { get; set; } //if 0, orders disabled
        public int ProductTypeID { get; set; }
        public ProductType ProductType { get; set; }
        public int CompanyID { get; set; }
        public Company Company { get; set; }
        public byte[] Thumbnail { get; set; }
        public bool AvailableForCustom { get; set; }
        //
        public string CompanyName { get; set; }
        public string ProductTypeName { get; set; }
        public string ProductNamePrice { get; set; }
        public string PriceWithCurrency { get; set; }
        //for discounts
        public bool Discounted { get; set; }
        public string DiscountedString { get; set; }
        public string DiscountedPrice { get; set; }
    }
}
