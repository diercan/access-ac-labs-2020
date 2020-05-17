using Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Domain.EmployeeRoles.GetOrdersOp
{
    public struct GetOrdersCmd
    {
        public Restaurant Restaurant { get; }

        public GetOrdersCmd(Restaurant restaurant)
        {
            Restaurant = restaurant;
        }
    }
}
