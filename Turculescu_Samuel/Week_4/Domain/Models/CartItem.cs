using Persistence.EfCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Models
{
    public class CartItem
    {
        public string Name { get; set; }
        public string SpecialRequests { get; set; }
        public uint Quantity { get; set; }
        public double Price { get; set; }
        public MenuItem MenuItem { get; set; }

        public CartItem(string name, string specialRequests, uint quantity, double price, MenuItem menuItem)
        {
            Name = name;   
            SpecialRequests = specialRequests;
            Quantity = quantity;
            Price = price;
            MenuItem = menuItem;
        }
    }
}
