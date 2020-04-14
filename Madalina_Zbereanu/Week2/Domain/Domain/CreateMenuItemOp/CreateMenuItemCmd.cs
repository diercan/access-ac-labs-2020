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
        public List<Ingredient> Ingredients { get; }
        public float Price { get; }

        public CreateMenuItemCmd(Menu menu, string name, List<Ingredient> ingredients, float price)
        {
            Menu = menu;
            Name = name;
            Ingredients = ingredients;
            Price = price;
        }
    }
}
