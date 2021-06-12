using System;
using System.Collections.Generic;
using System.Text;

namespace PeripheralTech.Model.Requests
{
    public class UserReviewUpsertRequest
    {
        public int UserID { get; set; }
        public int ProductID { get; set; }
        public DateTime Date { get; set; }
        //public int Grade { get; set; }
        public decimal Grade { get; set; }
        public string Comment { get; set; }
    }
}
