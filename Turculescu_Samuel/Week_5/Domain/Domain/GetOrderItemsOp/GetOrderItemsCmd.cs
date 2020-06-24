using Persistence.EfCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Domain.GetOrderItemsOp
{
    public struct GetOrderItemsCmd
    {
        public List<OrderItem> OrderItems { get; }
        public GetOrderItemsCmd(List<OrderItem> orderItems)
        {
            OrderItems = orderItems;
        }
    }
}
