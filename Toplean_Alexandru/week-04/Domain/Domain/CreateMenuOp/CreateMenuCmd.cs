using Domain.Models;
using Persistence.EfCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Domain.CreateMenuOp
{
    public struct CreateMenuCmd
    {
        public int RestaurantId { get; set; }
        public String Name { get; set; }
        public MenuType MenuTypes { get; set; }
        public MenuVisibilityTypes MenuVisibilityTypes { get; set; }
        public String? Hours { get; set; }
        public Restaurant Restaurant { get; set; }

        public CreateMenuCmd(int restaurantId, String name, String menuType, bool isVisible, string hours, Restaurant restaurant)
        {
            RestaurantId = restaurantId;
            Name = name;
            MenuTypes = 0;
            Enum.TryParse(menuType, out MenuType MenuType);
            if
                (isVisible == true) MenuVisibilityTypes = MenuVisibilityTypes.RegularMenu;
            else
                MenuVisibilityTypes = MenuVisibilityTypes.SpecialMenu;
            Hours = hours;
            Restaurant = restaurant;
        }

        public (bool, String) IsValid() => (true, "None");
    }
}