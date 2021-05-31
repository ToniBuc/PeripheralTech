using System;
using System.Collections.Generic;
using System.Text;

namespace PeripheralTech.Model
{
    public class StaffReview
    {
        public int StaffReviewID { get; set; }
        public int ProductID { get; set; }
        public Product Product { get; set; }
        public int UserID { get; set; }
        public User User { get; set; }
        public DateTime Date { get; set; }
        public int Grade { get; set; }
        public string Specifications { get; set; }
        public string ReviewContent { get; set; }
    }
}
