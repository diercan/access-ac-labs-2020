using System;
using System.Collections.Generic;
using System.Text;
using Domain.Models;

namespace Domain.Domain.CreateOrderOp
{
    public struct CreateOrderCmd
    {
        public Client Client { get; }

        public Restaurant Restaurant { get; }
        public uint OrderId { get; }
        public List<MenuItem> MenuItems { get; }

        public CreateOrderCmd(Client client, Restaurant restaurant, uint orderId, List<MenuItem> menuItems)
        {
            Client = client;
            Restaurant = restaurant;
            OrderId = orderId;
            MenuItems = menuItems;
        }
    }
}
