using Domain.Models;
using Persistence.EfCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Domain.GetOrdersOp
{
    public struct GetOrdersCmd
    {
        public List<Order> Orders { get; }

        public GetOrdersCmd(List<Order> orders)
        {
            Orders = orders;
        }
    }
}
