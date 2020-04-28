using System;
using System.Collections.Generic;
using System.Text;
namespace Domain.Models
{
    public class MenuItem
    {
        //public MenuItem() { }
        public Menu Menu { get; }
        public string Title { get; }
        public uint Price { get; }

        public List<string> Ingredients { get; }

        public MenuItem(Menu menu, string title, uint price, List<string> ingredients)
        {
            Menu = menu;
            Title = title;
            Price = price;
            Ingredients = ingredients;
        }
    }
}