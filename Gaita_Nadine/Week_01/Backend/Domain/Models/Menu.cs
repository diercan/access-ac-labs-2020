using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Models
{

    public enum MenuType
    {
        Vegan,
        Meat,
        Beverages,
        Pasta
    }

    public class Menu
    {
        public string Name { get; }
        public MenuType MenuType { get; }

        public List<MenuItem> MenuItems { get; } = new List<MenuItem>();

        public Menu(string name, MenuType menuType)
        {
            Name = name;
            MenuType = menuType;
        }
    }
}
