using System;
using System.Collections.Generic;
using System.Text;

namespace PeripheralTech.Model
{
    public class City
    {
        public int CityID { get; set; }
        public string Name { get; set; }
        public int CountryID { get; set; }
        public Country Country { get; set; }
        public string CountryName { get; set; }
        public string ZIPCode { get; set; }
    }
}
