using System;
using System.Collections.Generic;
using System.Text;

namespace PeripheralTech.Model.Requests
{
    public class OrderInsertRequest
    {
        //public int ProductID { get; set; }
        public int UserID { get; set; }
        public int OrderStatusID { get; set; }
        public DateTime Date { get; set; }
        public string Comment { get; set; }
    }
}
