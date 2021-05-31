using System;
using System.Collections.Generic;
using System.Text;

namespace PeripheralTech.Model.Requests
{
    public class ProductImageUpsertRequest
    {
        public int ProductID { get; set; }
        public byte[] Image { get; set; }
    }
}
