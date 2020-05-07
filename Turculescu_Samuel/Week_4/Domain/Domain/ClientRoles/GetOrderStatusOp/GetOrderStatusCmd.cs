using Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Domain.ClientRoles.GetOrderStatusOp
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
