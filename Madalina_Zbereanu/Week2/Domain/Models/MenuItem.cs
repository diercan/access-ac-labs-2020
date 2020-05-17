using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Models
{
    public class MenuItem
    {
        public Menu Menu { get; }
        public string Name { get; }
        public List<Ingredient> Ingredients { get; }
        public float Price { get; }
       

        public MenuItem(Menu menu, string name, List<Ingredient> ingredients, float price) {
            Menu = menu;
            Name = name;
            Ingredients = ingredients;
            Price = price;
        }
    }
}