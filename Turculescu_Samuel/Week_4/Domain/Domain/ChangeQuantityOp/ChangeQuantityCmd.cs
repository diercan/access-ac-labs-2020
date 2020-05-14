using Domain.Models;
using Persistence.EfCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Domain.ChangeQuantityOp
{
    public struct ChangeQuantityCmd
    {
        public string SessionId { get; }
        public OrderItem OrderItem { get; }
        public uint NewQuantity { get; }

        public ChangeQuantityCmd(string sessionId, OrderItem orderItem, uint newQuantity)
        {
            SessionId = sessionId;
            OrderItem = orderItem;
            NewQuantity = newQuantity;
        }
    }
}
