using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace PeripheralTech.WebAPI.Database
{
    public class Product
    {
        public int ProductID { get; set; }
        public string Name { get; set; }
        public string? Description { get; set; }
        [Column(TypeName = "DECIMAL(18,2)")]
        public decimal Price { get; set; }
        public int AmountInStock { get; set; } //if 0, orders disabled
        public int ProductTypeID { get; set; }
        public ProductType ProductType { get; set; }
        public int CompanyID { get; set; }
        public Company Company{ get; set; }
    }
}
