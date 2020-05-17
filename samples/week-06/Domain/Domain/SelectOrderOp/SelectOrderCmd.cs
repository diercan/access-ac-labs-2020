using Persistence.EfCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Domain.SelectOrderOp
{
    public class SelectOrderCmd
    {
        public Order Order { get; }

        public SelectOrderCmd(Order order)
        {
            Order = order;
        }
    }
}