using Domain.Models;
using Persistence.EfCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Domain.ClientRoles.PlaceOrderOp
{
    public struct PlaceOrderCmd
    {
        public Client Client { get; }
        public RestaurantAgg Restaurant { get; }
        public Cart Cart { get; }
        public uint TableNumber { get; }

        public PlaceOrderCmd(Client client, RestaurantAgg restaurant, Cart cart, uint tableNumber = 0)
        {
            Client = client;
            Restaurant = restaurant;
            Cart = cart;
            TableNumber = tableNumber;
        }

    }
}
