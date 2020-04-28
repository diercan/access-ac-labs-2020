using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Models
{

    public enum MenuType
    {
        Vegan,
        Meat,
        Beverages
    }

    public class Menu
    {
        public string Name { get; }
        public MenuType MenuType { get; }
        public List<MenuItem> MenuItems { get; set; }
        public Menu(string name)
        {
            Name = name;
            MenuItems = new List<MenuItem>();
        }
    }
}
