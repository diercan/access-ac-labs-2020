using Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Domain.ClientRoles.AddToCartOp
{
    public struct AddToCartCmd
    {
        public string SessionId { get; }
        public Client Client { get; }
        public MenuItem MenuItem { get; }
        public uint Quantity { get; }
        public string SpecialRequests { get; }

        public AddToCartCmd(string sessionId, Client client, MenuItem menuItem, uint quantity, string specialRequests)
        {
            SessionId = sessionId;
            Client = client;
            MenuItem = menuItem;
            Quantity = quantity;
            SpecialRequests = specialRequests;
        }
    }
}
