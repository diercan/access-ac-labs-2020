using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Models
{
    public class Cart
    {
        public string SessionId { get; }

        public Client Client { get; }
        public MenuItem MenuItem { get; }

        public uint Qty { get; }

        public Cart(string sessionId, Client client, uint qty, MenuItem menuItem)
        {
            SessionId = sessionId;
            Client = client;
            Qty = qty;
            MenuItem = menuItem;
        }

    }
}
