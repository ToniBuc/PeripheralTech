using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PeripheralTech.WebAPI.Database
{
    public class ProductVideo
    {
        public int ProductVideoID { get; set; }
        public int ProductID { get; set; }
        public Product Product { get; set; }
        public byte[] Video { get; set; }
        public string Title { get; set; }
    }
}
