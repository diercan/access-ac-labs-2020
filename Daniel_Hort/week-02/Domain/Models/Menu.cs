using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Models
{
    [Flags]
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
        public List<MenuItem> Items { get; }

        public Menu(string name, MenuType menuType)
        {
            Name = name;
            MenuType = menuType;
            Items = new List<MenuItem>();
        }
    }
}
