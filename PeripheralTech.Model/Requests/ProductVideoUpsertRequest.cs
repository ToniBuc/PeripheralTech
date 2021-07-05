using System;
using System.Collections.Generic;
using System.Text;

namespace PeripheralTech.Model.Requests
{
    public class ProductVideoUpsertRequest
    {
        public int ProductID { get; set; }
        public byte[] Video { get; set; }
        public string Title { get; set; }
    }
}
