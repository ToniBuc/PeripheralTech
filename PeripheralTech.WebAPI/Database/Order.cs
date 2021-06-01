using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PeripheralTech.WebAPI.Database
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
    }
}
