using Domain.Models;
using Persistence.EfCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Domain.ClientRoles.AddToCartOp
{
    public struct AddToCartCmd
    {
        public string SessionId { get; }
        public MenuItem MenuItem { get; }
        public uint Quantity { get; }
        public string SpecialRequests { get; }

        public AddToCartCmd(string sessionId, MenuItem menuItem, uint quantity, string specialRequests)
        {
            SessionId = sessionId;
            MenuItem = menuItem;
            Quantity = quantity;
            SpecialRequests = specialRequests;
        }
    }
}
