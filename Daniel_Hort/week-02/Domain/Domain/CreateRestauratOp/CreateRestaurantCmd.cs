using Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Domain.CreateRestauratOp
{
    public struct CreateRestaurantCmd
    {
        public string Name { get; }
        public List<Restaurant> Restaurants { get; }

        public CreateRestaurantCmd(List<Restaurant> restaurants, string name)
        {
            Name = name;
            Restaurants = restaurants;
        }
    }
}
