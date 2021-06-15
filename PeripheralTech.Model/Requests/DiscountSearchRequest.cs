using System;
using System.Collections.Generic;
using System.Text;

namespace PeripheralTech.Model.Requests
{
    public class DiscountSearchRequest
    {
        public int? DiscountID { get; set; }
        public int? ProductID { get; set; }
        //public DateTime From { get; set; }
        //public DateTime To { get; set; }
    }
}
