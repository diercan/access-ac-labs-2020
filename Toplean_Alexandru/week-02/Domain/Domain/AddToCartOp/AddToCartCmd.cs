using Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Domain.AddToCartOp
{
    public struct AddToCartCmd
    {
        public String SessionID;
        public List<CartItem> CartItems;

        public AddToCartCmd(String sessionId, List<CartItem> items)
        {
            SessionID = sessionId;
            CartItems = items;
        }

        public (bool, String) IsValid()
        {
            // Cart should not be null
            if (CartItems == null)
                return (false, "There are no orders in the cart.");

            // Cart should not be null
            if (CartItems.Count == 0)
                return (false, "There are no orders in the cart.");

            return (true, "None");
        }
    }
}