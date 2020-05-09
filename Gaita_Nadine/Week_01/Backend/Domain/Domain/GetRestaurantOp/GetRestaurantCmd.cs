using Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Domain.GetRestaurantOp
{
    public class GetRestaurantCmd
    {
        public Restaurant Restaurant { get; }

        public GetRestaurantCmd(Restaurant restaurant)
        {
            Restaurant = restaurant;
        }
    }
}
