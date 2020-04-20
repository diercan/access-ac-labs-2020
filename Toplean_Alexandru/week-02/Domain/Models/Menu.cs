using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Models
{
    public enum MenuVisibilityTypes
    {
        RegularMenu,
        SpecialMenu
    }

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

        public MenuVisibilityTypes MenuVisibilityTypes { get; set; }

        public List<MenuItem> Items { get; set; } = new List<MenuItem>();
        public String Hour { get; set; }

        public Menu(string name, MenuType menuType, MenuVisibilityTypes menuVisibility, String hour = null)
        {
            Name = name;
            MenuType = menuType;
            MenuVisibilityTypes = menuVisibility;
            Hour = hour;
        }
    }
}