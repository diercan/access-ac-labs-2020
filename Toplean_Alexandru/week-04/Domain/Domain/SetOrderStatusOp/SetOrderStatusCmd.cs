using Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;
using static Domain.Models.Cart;

namespace Domain.Domain.SetOrderStatusOp
{
    public struct SetOrderStatusCmd
    {
        public ClientAgg ClientAgg { get; }
        public CartStatus CartStatus { get; }

        public SetOrderStatusCmd(ClientAgg client, CartStatus newStatus)
        {
            ClientAgg = client;
            CartStatus = newStatus;
        }

        // Checks if there is a cart initialized. If the Cart is null, the function will return false;
        public bool IsValid() => ClientAgg.Cart == null ? false : true;
    }
}