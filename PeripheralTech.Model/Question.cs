using System;
using System.Collections.Generic;
using System.Text;

namespace PeripheralTech.Model
{
    public class Question
    {public int QuestionID { get; set; }
        public string Content { get; set; }
        public int CustomerID { get; set; }
        public User Customer { get; set; }
        public int StaffID { get; set; }
        public User Staff { get; set; }
        public bool Status { get; set; }
        
    }
}
