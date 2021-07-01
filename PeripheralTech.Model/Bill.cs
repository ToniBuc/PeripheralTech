using System;
using System.Collections.Generic;
using System.Text;

namespace PeripheralTech.Model
{
    public class Bill
    {
        public int BillID { get; set; }
        public DateTime Date { get; set; }
        public int OrderID { get; set; }
        public Order Order { get; set; }
        public decimal PaymentAmount { get; set; }
        public bool IsPaid { get; set; }
        //
        public string UserFullname { get; set; }
    }
}
