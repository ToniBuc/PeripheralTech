using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace PeripheralTech.Model.Requests
{
    public class DiscountUpsertRequest
    {
        public int ProductID { get; set; }
        [Column(TypeName = "DECIMAL(12,8)")]
        public decimal DiscountPercentage { get; set; }
        public DateTime From { get; set; }
        public DateTime To { get; set; }
    }
}
