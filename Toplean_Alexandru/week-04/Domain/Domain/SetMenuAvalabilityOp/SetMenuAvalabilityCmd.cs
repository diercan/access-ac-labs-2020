using Domain.Models;
using Persistence.EfCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Domain.SetMenuAvalabilityOp
{
    public struct SetMenuAvalabilityCmd
    {
        public int RestaurantId { get; }
        public MenuAgg MenuAgg { get; }
        public MenuVisibilityTypes MenuVisibilityTypes { get; }
        public String Hour { get; }

        public SetMenuAvalabilityCmd(int restaurantId, MenuAgg menuAgg, MenuVisibilityTypes type, String hour = null)
        {
            RestaurantId = restaurantId;
            MenuAgg = menuAgg;
            MenuVisibilityTypes = type;
            Hour = hour;
        }

        public (bool, String) IsValid()
        {
            // If a menu that is a special menu is set to special menu it will return false
            if (MenuVisibilityTypes == MenuVisibilityTypes.SpecialMenu && Hour == null)
                return (false, $"Cannot create a special menu without specified display hours");

            return (true, "None");
        }
    }
}