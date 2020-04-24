using Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Domain.GetMenuItemOp
{
    public struct GetMenuItemCmd
    {
        public Restaurant Restaurant { get; }
        public String MenuItemName { get; }
        public Menu Menu { get; }

        public GetMenuItemCmd(Restaurant restaurant, Menu menu, String itemName)
        {
            Restaurant = restaurant;
            MenuItemName = itemName;
            Menu = menu;
        }

        public (bool, String) IsValid()
        {
            return (true, "None");
        }
    }
}