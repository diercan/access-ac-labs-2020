using Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Domain.ClientRoles.PlaceOrderOp
{
    public struct PlaceOrderCmd
    {
        public Client Client { get; }
        public Restaurant Restaurant { get; }
        public Cart Cart { get; }
        public uint TableNumber { get; }

        public PlaceOrderCmd(Client client, Restaurant restaurant, Cart cart, uint tableNumber = 0)
        {
            Client = client;
            Restaurant = restaurant;
            Cart = cart;
            TableNumber = tableNumber;
        }

    }
}
