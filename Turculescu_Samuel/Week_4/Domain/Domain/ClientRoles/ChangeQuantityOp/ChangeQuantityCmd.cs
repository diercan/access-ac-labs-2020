using Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Domain.ClientRoles.ChangeQuantityOp
{
    public struct ChangeQuantityCmd
    {
        public string SessionId { get; }
        public CartItem CartItem { get; }
        public uint NewQuantity { get; }

        public ChangeQuantityCmd(string sessionId, CartItem cartItem, uint newQuantity)
        {
            SessionId = sessionId;
            CartItem = cartItem;
            NewQuantity = newQuantity;
        }
    }
}
