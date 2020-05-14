using Domain.Models;
using Persistence.EfCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Domain.CheckOrderPaymentOp
{
    public struct CheckOrderPaymentCmd
    {
        public Order Order { get; }

        public CheckOrderPaymentCmd(Order order)
        {
            Order = order;
        }
    }
}
