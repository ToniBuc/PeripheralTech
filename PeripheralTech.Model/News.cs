using System;
using System.Collections.Generic;
using System.Text;

namespace PeripheralTech.Model
{
    public class News
    {
        public int NewsID { get; set; }
        public string Title { get; set; }
        public int UserID { get; set; }
        public User User { get; set; }
        public DateTime Date { get; set; }
        public string Content { get; set; }
        public byte[] Thumbnail { get; set; }
        //
        public string Author { get; set; }
    }
}
