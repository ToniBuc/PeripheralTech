using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace PeripheralTech.WebAPI.Database
{
    public class Discount
    {
        public int DiscountID { get; set; }
        public int ProductID { get; set; }
        public Product Product { get; set; }
        [Column(TypeName = "DECIMAL(12,8)")]
        public decimal DiscountPercentage { get; set; }
        public DateTime From { get; set; }
        public DateTime To { get; set; }
    }
}
