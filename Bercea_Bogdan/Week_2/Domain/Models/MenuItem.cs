using System.Collections.Generic;

namespace Domain.Models
{
    public class MenuItem
    {
        public string ItemName { get; }
        public decimal ItemPrice { get; }
        public  List<string> Ingredients { get; }
        public List<string> Alergens { get; }
        public Menu Menu { get; }

        public MenuItem(string itemName, decimal price, List<string> ingredients,
            List<string> alergens, Menu menu)
        {
            ItemName = itemName;
            ItemPrice = price;
            Ingredients = ingredients;
            Alergens = alergens;
            Menu = menu;
        }
    }
}