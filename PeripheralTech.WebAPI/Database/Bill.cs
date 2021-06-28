using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace PeripheralTech.WebAPI.Database
{
    public class Bill
    {
        [Key]
        public int BillID { get; set; }
        [Required]
        public DateTime Date { get; set; }
        public int OrderID { get; set; }
        public Order Order { get; set; }
        [Required]
        [Column(TypeName = "DECIMAL(18,2)")]
        public decimal PaymentAmount { get; set; }
        [Required]
        [Column(TypeName = "BIT")]
        public bool IsPaid { get; set; }
    }
}
