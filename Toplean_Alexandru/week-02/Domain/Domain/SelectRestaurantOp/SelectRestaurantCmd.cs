using System;
using System.Collections.Generic;
using System.Text;
using static Domain.Models.Restaurant;

namespace Domain.Domain.SelectRestaurantOp
{
    public struct SelectRestaurantCmd
    {
        public String RestaurantName { get; }

        public SelectRestaurantCmd(String restaurantName)
        {
            RestaurantName = restaurantName;
        }

        public (bool, String) IsValid()
        {
            return (true, "None");
        }
    }
}