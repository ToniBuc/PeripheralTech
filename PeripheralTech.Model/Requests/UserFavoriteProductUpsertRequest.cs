using System;
using System.Collections.Generic;
using System.Text;

namespace PeripheralTech.Model.Requests
{
    public class UserFavoriteProductUpsertRequest
    {
        public int UserID { get; set; }
        public int ProductID { get; set; }
    }
}
