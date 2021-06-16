using System;
using System.Collections.Generic;
using System.Text;

namespace PeripheralTech.Model.Requests
{
    public class QuestionSearchRequest
    {
        public int? QuestionID { get; set; }
        public int? StaffID { get; set; }
        public bool? Status { get; set; }
        public string Claim { get; set; }
    }
}
