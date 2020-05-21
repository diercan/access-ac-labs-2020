using Domain.Models;
using Persistence.EfCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Domain.GetOrderStatusOp
{
    public struct GetOrderStatusCmd
    {
        public Order Order { get; }

        public GetOrderStatusCmd(Order order)
        {
            Order = order;
        }
    }
}
