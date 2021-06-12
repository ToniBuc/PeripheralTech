using System;
using System.Collections.Generic;
using System.Text;

namespace PeripheralTech.Model.Requests
{
    public class StaffReviewUpsertRequest
    {
        public int ProductID { get; set; }
        public int UserID { get; set; }
        public DateTime Date { get; set; }
        //public int Grade { get; set; }
        public decimal Grade { get; set; }
        public string Specifications { get; set; }
        public string ReviewContent { get; set; }
    }
}
