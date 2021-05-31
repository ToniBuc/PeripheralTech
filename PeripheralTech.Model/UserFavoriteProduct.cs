using System;
using System.Collections.Generic;
using System.Text;

namespace PeripheralTech.Model
{
    public class UserFavoriteProduct
    {
        public int UserFavoriteProductID { get; set; }
        public int UserID { get; set; }
        public User User { get; set; }
        public int ProductID { get; set; }
        public Product Product { get; set; }
    }
}
