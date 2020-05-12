using Domain.Models;
using Persistence.EfCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using static Domain.Domain.CreateMenuOp.CreateMenuResult;
using static Domain.Domain.CreateOrderOp.CreateOrderResult;

namespace Domain.Domain.CreateOrderOp
{
    public struct CreateOrderCmd
    {
        public Order Order { get; }

        public CreateOrderCmd(Order order)
        {
            Order = order;
        }
    }
}