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
        public string Ingredients { get; }
        public string Allergens { get; }
        public uint Price { get; }
        public CreateMenuItemCmd(Menu menu, string name, string ingredients, string allergens, uint price)
        {
            Menu = menu;
            Name = name;
            Ingredients = ingredients;
            Allergens = allergens;
            Price = price;
        }
    }
}