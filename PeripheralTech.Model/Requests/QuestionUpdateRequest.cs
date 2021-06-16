using System;
using System.Collections.Generic;
using System.Text;

namespace PeripheralTech.Model.Requests
{
    public class QuestionUpdateRequest
    {
        public int? StaffID { get; set; }
        public bool? Status { get; set; }
    }
}
