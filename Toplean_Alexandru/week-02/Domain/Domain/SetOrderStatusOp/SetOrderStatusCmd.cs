using Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;
using static Domain.Models.Cart;

namespace Domain.Domain.SetOrderStatusOp
{
    public struct SetOrderStatusCmd
    {
        public Cart Cart { get; }
        public CartStatus CartStatus { get; }

        public SetOrderStatusCmd(Cart cart, CartStatus newStatus)
        {
            Cart = cart;
            CartStatus = newStatus;
        }

        // Checks if there is a cart initialized. If the Cart is null, the function will return false;
        public bool IsValid() => Cart == null ? false : true;
    }
}