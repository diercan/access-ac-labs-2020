using System;
using System.Text;
using Persistence.EfCore;

namespace Domain.Domain.GetOrderOp
{
    public struct GetOrderCmd
    {
        public Order Order { get; }
        public GetOrderCmd(Order order)
        {
            Order = order;
        }
    }
}
