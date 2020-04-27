using Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Domain.ChangeQtyOp
{
    public struct ChangeQtyCmd
    {
        public uint NewQty { get; }

        public MenuItem MenuItem { get; }

        public string SessionId { get; }
        public Client Client { get; }

        public ChangeQtyCmd(string sessionId,Client client, MenuItem menuItem, uint newQty)
        {
            SessionId = sessionId;
            Client = client;
            MenuItem = menuItem;
            NewQty = newQty;
        }
    }
}
