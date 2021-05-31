using System;
using System.Collections.Generic;
using System.Text;

namespace PeripheralTech.Model
{
    public class ProductVideo
    {
        public int ProductVideoID { get; set; }
        public int ProductID { get; set; }
        public Product Product { get; set; }
        public byte[] Video { get; set; }
    }
}
