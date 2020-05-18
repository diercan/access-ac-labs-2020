using Domain.Models;
using Persistence.EfCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Domain.GetOrdersOp
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
