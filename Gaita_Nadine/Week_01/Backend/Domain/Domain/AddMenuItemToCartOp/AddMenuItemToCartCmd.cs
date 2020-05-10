using Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Domain.AddToCartOp
{
    public class AddMenuItemToCartCmd
    {
        public Client Client { get; }
        public MenuItem MenuItem { get; }
        public ushort Quantity { get; }
        public AddMenuItemToCartCmd(Client client, MenuItem menuItem, ushort quantity)
        {
            Client = client;
            MenuItem = menuItem;
            Quantity = quantity;
        }
    }
}
