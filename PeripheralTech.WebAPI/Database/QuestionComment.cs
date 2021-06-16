using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PeripheralTech.WebAPI.Database
{
    public class QuestionComment
    {
        public int QuestionCommentID { get; set; }
        public string Content { get; set; }
        public int QuestionID { get; set; }
        public Question Question { get; set; }
        public int UserID { get; set; }
        public User User { get; set; }
        public DateTime Date { get; set; }
    }
}
