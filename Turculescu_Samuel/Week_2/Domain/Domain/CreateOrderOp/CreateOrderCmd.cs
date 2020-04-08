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
        public int IdOrder { get; }
        public List<MenuItem> MenuItems { get; }

        public CreateOrderCmd(Client client, Restaurant restaurant, int idOrder, List<MenuItem> menuItems)
        {
            Client = client;
            Restaurant = restaurant;
            IdOrder = idOrder;
            MenuItems = menuItems;
        }
    }
}
