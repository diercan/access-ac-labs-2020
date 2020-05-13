using Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;
using static Domain.Models.Cart;

namespace Domain.Domain.RequestPaymentOp
{
    public struct RequestPaymentCmd
    {
        public ClientAgg ClientAgg { get; }

        public RequestPaymentCmd(ClientAgg clientAgg)
        {
            ClientAgg = clientAgg;
        }

        // Checks if the session still exists. If the SessionID is in the <SessionID, List<Cart>> Dictionary, the function will return false;
        public (bool, String) IsValid()
        {
            return (true, "None");
        }
    }
}