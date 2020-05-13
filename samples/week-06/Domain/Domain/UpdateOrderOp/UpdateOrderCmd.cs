using Domain.Models;
using Persistence.EfCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Domain.UpdateOrderOp
{
    public class UpdateOrderCmd
    {
        public Order Order { get; }

        public UpdateOrderCmd(Order order)
        {
            Order = order;
        }
    }
}