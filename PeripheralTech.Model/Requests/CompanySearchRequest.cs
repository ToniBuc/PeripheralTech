using System;
using System.Collections.Generic;
using System.Text;

namespace PeripheralTech.Model.Requests
{
    public class CompanySearchRequest
    {
        public string CompanyName { get; set; }
        // for reports
        public DateTime From { get; set; }
        public DateTime To { get; set; }
    }
}
