using System;
using System.Collections.Generic;
using System.Text;
using static Domain.Models.Cart;

namespace Domain.Domain.GetPaymentStatusOp
{
    public struct GetPaymentStatusCmd
    {
        public String SessionID { get; }

        public GetPaymentStatusCmd(String sessionID)
        {
            SessionID = sessionID;
        }
    }
}