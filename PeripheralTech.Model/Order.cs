using System;
using System.Collections.Generic;
using System.Text;

namespace PeripheralTech.Model
{
    public class Order
    {
        public int OrderID { get; set; }
        //public int ProductID { get; set; }
        //public Product Product { get; set; }
        public int UserID { get; set; }
        public User User { get; set; }
        public int OrderStatusID { get; set; }
        public OrderStatus OrderStatus { get; set; }
        public DateTime Date { get; set; }
        public string Comment { get; set; }
        //
        public decimal TotalPayment { get; set; }
        public string DateShort { get; set; }
    }
}
