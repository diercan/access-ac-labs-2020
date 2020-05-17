using Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Domain.EmployeeRoles.GetOrdersOp
{
    public struct GetOrdersCmd
    {
        public RestaurantAgg Restaurant { get; }

        public GetOrdersCmd(RestaurantAgg restaurant)
        {
            Restaurant = restaurant;
        }
    }
}
