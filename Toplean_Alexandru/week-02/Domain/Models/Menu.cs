using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Models
{
    public enum MenuErrorCode
    {
        None,
        ExistentMenu,
        UnknownError,
        NullRestaurant,
        EmptyField,
        IllegalCharacter
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

        public Menu(string name, MenuType menuType)
        {
            Name = name;
            MenuType = menuType;
        }
    }
}