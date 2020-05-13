using Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;
using static Domain.Models.Cart;

namespace Domain.Domain.GetPaymentStatusOp
{
    public struct GetPaymentStatusCmd
    {
        public ClientAgg ClientAgg { get; }

        public GetPaymentStatusCmd(ClientAgg clientAgg)
        {
            ClientAgg = clientAgg;
        }
    }
}