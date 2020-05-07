using System;
using System.Collections.Generic;
using System.Text;
using Domain.Models;
using Persistence.EfCore;

namespace Domain.Domain.ClientRoles.GetRestaurantOp
{
    public struct GetRestaurantCmd
    {
        public Restaurant Restaurant { get; }

        public GetRestaurantCmd(Restaurant restaurant)
        {
            Restaurant = restaurant;
        }
    }
}
