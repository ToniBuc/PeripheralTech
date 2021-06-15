﻿using System;
using System.Collections.Generic;
using System.Text;

namespace PeripheralTech.Model.Requests
{
    public class QuestionUpsertRequest
    {
        public string Title { get; set; }
        public string Content { get; set; }
        public int CustomerID { get; set; }
        public int StaffID { get; set; }
        public bool Status { get; set; }
        public DateTime Date { get; set; }
    }
}
