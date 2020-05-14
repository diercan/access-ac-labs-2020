using Domain.Models;
using Persistence.EfCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Domain.PayOrderOp
{
    public struct PayOrderCmd
    {
        public Client Client { get; }
        public Order Order { get; }
        public uint Tip { get; }

        public PayOrderCmd(Client client, Order order, uint tip = 0)
        {
            Client = client;
            Order = order;
            Tip = tip;
        }
    }
}
