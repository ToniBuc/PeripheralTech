using System;
using System.Collections.Generic;
using System.Text;

namespace PeripheralTech.Model
{
    public class ProductImage
    {
        public int ProductImageID { get; set; }
        public int ProductID { get; set; }
        public Product Product { get; set; }
        public byte[] Image { get; set; }
    }
}
