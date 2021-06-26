using System;
using System.Collections.Generic;
using System.Text;

namespace PeripheralTech.Mobile.Models
{
    public enum MenuItemType
    {
        Browse,
        About,
        Profile,
        ProductCatalog,
        News, 
        Checkout,
        Logout
    }
    public class HomeMenuItem
    {
        public MenuItemType Id { get; set; }

        public string Title { get; set; }
    }
}
