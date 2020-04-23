using Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Domain.ClientRoles.PlaceOrderOp
{
    public struct PlaceOrderCmd
    {
        public Cart Cart { get; }
        public Client Client { get; }
        public uint Tip { get; }
        public uint TableNumber { get; }

        public PlaceOrderCmd(Client client, Cart cart, uint tip = 0, uint tableNumber = 0)
        {
            Client = client;
            Cart = cart;
            Tip = tip;
            TableNumber = tableNumber;
        }

    }
}
