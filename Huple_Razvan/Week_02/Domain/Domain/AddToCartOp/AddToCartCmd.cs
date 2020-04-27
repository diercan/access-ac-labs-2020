using Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Domain.AddToCartOp
{
    public struct AddToCartCmd
    {
        public string SessionId { get; }

        public Client Client { get; }
        public MenuItem MenuItem { get; }

        public uint Qty { get; }

        public AddToCartCmd(string sessionId, Client client, MenuItem menuItem, uint qty)
        {
            SessionId = sessionId;
            Client = client;
            MenuItem = menuItem;
            Qty = qty;
        }
    }
}
