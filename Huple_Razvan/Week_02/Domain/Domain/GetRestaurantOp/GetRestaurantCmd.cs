using Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Domain.GetRestaurantOp
{
    public struct GetRestaurantCmd
    {
        public List<Restaurant> restaurants;
        public Restaurant Restaurant { get; }

        public GetRestaurantCmd(Restaurant restaurant)
        {
            Restaurant = restaurant;
            restaurants = new List<Restaurant>();
        }
    }
}
