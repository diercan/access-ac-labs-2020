using System;
using System.Text;
using Persistence.EfCore;

namespace Domain.Domain.GetOrderItemOp
{
    public struct GetOrderItemCmd
    {
        public OrderItem OrderItem { get; }
        public GetOrderItemCmd(OrderItem orderItem)
        {
            OrderItem = orderItem;
        }
    }
}
