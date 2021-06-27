using System;
using System.Collections.Generic;
using System.Text;

namespace PeripheralTech.Model.Requests
{
    public class BillSearchRequest
    {
        public int? BillID { get; set; }
        public int? PatientID { get; set; }
    }
}
