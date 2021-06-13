using System;
using System.Collections.Generic;
using System.Text;

namespace PeripheralTech.Model.Requests
{
    public class NewsUpsertRequest
    {
        public string Title { get; set; }
        public int UserID { get; set; }
        public DateTime Date { get; set; }
        public string Content { get; set; }
        public byte[] Thumbnail { get; set; }
    }
}
