using System;
using System.Collections.Generic;
using System.Text;

namespace PeripheralTech.Model.Requests
{
    public class BillUpsertRequest
    {
        public DateTime Date { get; set; }
        public int OrderID { get; set; }
        public decimal PaymentAmount { get; set; }
    }
}
