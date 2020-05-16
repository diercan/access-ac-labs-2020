using Domain.Models;
using Infra.Free;
using Persistence.EfCore;
using System;
using System.Collections.Generic;
using System.Text;
using static Domain.Models.Cart;

namespace Domain.Domain.GetPaymentStatusOp
{
    public struct GetPaymentStatusCmd
    {
        public Order Order { get; }

        public GetPaymentStatusCmd(Order order)
        {
            Order = order;
        }

        public (bool, String) IsValid()
        {
            if (Order.TotalPrice < 0)
            {
                return (false, "Total price cannot be negative");
            }

            return (true, "");
        }
    }
}