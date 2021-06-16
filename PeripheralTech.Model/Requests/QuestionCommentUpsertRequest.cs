using System;
using System.Collections.Generic;
using System.Text;

namespace PeripheralTech.Model.Requests
{
    public class QuestionCommentUpsertRequest
    {
        public string Content { get; set; }
        public int QuestionID { get; set; }
        public int UserID { get; set; }
        public DateTime Date { get; set; }
    }
}
