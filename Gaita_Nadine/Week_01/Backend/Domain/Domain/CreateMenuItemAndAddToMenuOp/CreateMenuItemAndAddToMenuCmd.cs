using Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Domain.CreateMenuItemOp
{
    public struct CreateMenuItemAndAddToMenuCmd
    {
        public Menu Menu { get; }
        public string Name { get; }
        public double Price { get; }
        public List<Ingredient> Ingredients { get; }
        public CreateMenuItemAndAddToMenuCmd(Menu menu, string name, double price, List<Ingredient> ingredients)
        {
            Menu = menu;
            Name = name;
            Price = price;
            Ingredients = ingredients;
        }
    }
}
