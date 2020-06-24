using System;
using System.Collections.Generic;
using System.Text;
using Domain.Models;
using Persistence.EfCore;

namespace Domain.Domain.GetRestaurantsOp
{
    public struct GetRestaurantsCmd
    {
        public List<Restaurant> Restaurants { get; }

        public GetRestaurantsCmd(List<Restaurant> restaurants)
        {
            Restaurants = restaurants;
        }
    }
}
