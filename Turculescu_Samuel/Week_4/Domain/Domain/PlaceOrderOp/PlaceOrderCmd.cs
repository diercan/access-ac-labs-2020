using Domain.Models;
using Persistence.EfCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Domain.PlaceOrderOp
{
    public struct PlaceOrderCmd
    {
        public Client Client { get; }
        public Restaurant Restaurant { get; }
        public double TotalPrice { get; }
        public uint TableNumber { get; }

        public PlaceOrderCmd(Client client, Restaurant restaurant, double totalPrice, uint tableNumber = 0)
        {
            Client = client;
            Restaurant = restaurant;
            TotalPrice = totalPrice;            
            TableNumber = tableNumber;
        }

    }
}
