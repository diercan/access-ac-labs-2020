using Domain.Models;
using Persistence.EfCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Domain.CreateOrderItemOp
{
    public struct CreateOrderItemCmd
    {
        public CartItem CartItem { get; }
        public Order Order { get; }

        public CreateOrderItemCmd(CartItem cartItem, Order order)
        {            
            CartItem = cartItem;
            Order = order;
        }
    }
}
