using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Text;

namespace Domain.Models
{
    public class CartItem
    {
        public string Name { get; }
        public string SpecialRequests { get; set; }
        public uint Quantity { get; set; }
        public double Price { get; }
        public MenuItemAgg MenuItem { get; }

        public CartItem(MenuItemAgg menuItem, string name, string specialRequests, uint quantity, double price)
        {
            MenuItem = menuItem;
            Name = name;
            SpecialRequests = specialRequests;
            Quantity = quantity;
            Price = price;
        }
    }
}
