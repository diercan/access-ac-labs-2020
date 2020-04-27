using Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Domain.GetRestaurantOp
{
    public struct GetRestaurantCmd
    {
        public List<Restaurant> restaurants;
        public string Name { get; }

        public GetRestaurantCmd(string name)
        {
            Name = name;
            restaurants = new List<Restaurant>() {new Restaurant("mcdonalds"),new Restaurant("kfc")};
        }
    }
}
