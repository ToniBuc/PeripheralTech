using System;
using System.Collections.Generic;
using System.Text;

namespace PeripheralTech.Mobile.Models
{
    public enum MenuItemType
    {
        //Browse,
        Home,
        About,
        Profile,
        ProductCatalog,
        CustomOrder,
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
