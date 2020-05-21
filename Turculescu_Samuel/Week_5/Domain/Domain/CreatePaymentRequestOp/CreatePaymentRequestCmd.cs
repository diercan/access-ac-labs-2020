using Domain.Models;
using Persistence.EfCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Domain.CreatePaymentRequestOp
{
    public struct CreatePaymentRequestCmd
    {
        public Order Order { get; }

        public CreatePaymentRequestCmd(Order order)
        {
            Order = order;
        }

    }
}
