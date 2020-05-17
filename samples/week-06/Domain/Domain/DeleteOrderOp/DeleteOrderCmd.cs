using Persistence.EfCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Domain.DeleteOrderOp
{
    public class DeleteOrderCmd
    {
        public Order Order { get; }

        public DeleteOrderCmd(Order order)
        {
            Order = order;
        }
    }
}