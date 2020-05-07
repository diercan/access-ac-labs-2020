using System.Security.Cryptography.X509Certificates;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Models
{
    public enum MenuItemState
    {
        Available,
        Unavailable
    }

    public class MenuItem
    {
        public string Name { get; set; }
        public double Price { get; set; }
        public uint Quantity { get; set; }
        public string Ingredients { get; set; }
        public string Allergens { get; set; }
        public MenuItemState MenuItemState { get; set; }

        public MenuItem(string name, double price, uint quantity, string ingredients, string allergens, MenuItemState menuItemState) 
        {
            Name = name;
            Price = price;
            Quantity = quantity;
            Ingredients = ingredients;
            Allergens = allergens;
            MenuItemState = menuItemState;
        }
    }
}