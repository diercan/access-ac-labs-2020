using System.Collections.Generic;

namespace Domain.Models
{
    public class MenuItem
    {
        public Menu Menu { get; }
        public string Name { get; }
        public double Price { get; }
        public List<Ingredient> Ingredients { get; }
        public MenuItem(Menu menu, string name, double price, List<Ingredient> ingredients) {
            Menu = menu;
            Name = name;
            Price = price;
            Ingredients = ingredients;
        }
    }
}