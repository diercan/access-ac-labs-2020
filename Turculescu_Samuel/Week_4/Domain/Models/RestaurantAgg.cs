using Persistence.EfCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Models
{
    public class RestaurantAgg
    {
        public Restaurant Restaurant { get; set; }

        public RestaurantAgg(Restaurant restaurant)
        {
            Restaurant = restaurant;
        }
    }
}
