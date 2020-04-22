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
        public MenuType MenuType { get; }

        public Menu(MenuType menuType)
        {
            MenuType = menuType;
        }
    }
}
