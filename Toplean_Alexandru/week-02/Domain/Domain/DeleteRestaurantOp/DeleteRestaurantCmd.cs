using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Domain.DeleteRestaurantOp
{
    public struct DeleteRestaurantCmd
    {
        public String RestaurantName { get; }

        public DeleteRestaurantCmd(String restaurantName)
        {
            RestaurantName = restaurantName;
        }
    }
}