using System;
using System.Collections.Generic;
using System.Text;

namespace PeripheralTech.Model.Requests
{
    public class BillSearchRequest
    {
        public int? BillID { get; set; }
        public int? CustomerID { get; set; }
        // for reports
        public DateTime From { get; set; }
        public DateTime To { get; set; }
    }
}
