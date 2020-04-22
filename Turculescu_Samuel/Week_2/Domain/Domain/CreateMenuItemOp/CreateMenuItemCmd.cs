using Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Domain.CreateMenuItemOp
{
    public struct CreateMenuItemCmd
    {
        public Menu Menu { get; }
        public string Name { get; }
        public float Price { get; }
        public int Quantity { get; }
        public string Ingredients { get; }
        public string Allergens { get; }

        public CreateMenuItemCmd(Menu menu, string name, float price, int quantity, string ingredients, string allergens)
        {
            Menu = menu;
            Name = name;
            Price = price;
            Quantity = quantity;
            Ingredients = ingredients;
            Allergens = allergens;
        }
    }
}
