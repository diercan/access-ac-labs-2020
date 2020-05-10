using Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Domain.ClientRoles.GetMenusOp
{
    public struct GetMenusCmd
    {
        public RestaurantAgg Restaurant { get; }

        public GetMenusCmd(RestaurantAgg restaurant)
        {
            Restaurant = restaurant;            
        }
    }
}
