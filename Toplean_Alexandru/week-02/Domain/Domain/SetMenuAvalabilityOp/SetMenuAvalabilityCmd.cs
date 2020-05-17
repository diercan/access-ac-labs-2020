using Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Domain.SetMenuAvalabilityOp
{
    public struct SetMenuAvalabilityCmd
    {
        public Restaurant Restaurant { get; }
        public Menu Menu { get; }
        public MenuVisibilityTypes MenuVisibilityTypes { get; }
        public String Hour { get; }

        public SetMenuAvalabilityCmd(Restaurant restaurant, Menu menu, MenuVisibilityTypes type, String hour = null)
        {
            Restaurant = restaurant;
            Menu = menu;
            MenuVisibilityTypes = type;
            Hour = hour;
        }

        public (bool, String) IsValid()
        {
            // If a menu that is a special menu is set to special menu it will return false
            if (Menu.MenuVisibilityTypes == MenuVisibilityTypes && MenuVisibilityTypes == MenuVisibilityTypes.SpecialMenu)
                return (false, $"This menu already is a Special Menu and the display time is at {Menu.Hour}");

            // If a regular menu is set to a regualt menu it will return false
            if (Menu.MenuVisibilityTypes == MenuVisibilityTypes && MenuVisibilityTypes == MenuVisibilityTypes.RegularMenu)
                return (false, $"This menu already is a Regular Menu");

            // Hour is used either to set a  special menu or to know the key to remove a special menu. Hour is used as a Key in the SpecialMenus Dictionary
            // Key - Hour, Value - List<Menu>
            if (Hour == null)
                return (false, "The menu must have a time to be displayed");

            return (true, "None");
        }
    }
}