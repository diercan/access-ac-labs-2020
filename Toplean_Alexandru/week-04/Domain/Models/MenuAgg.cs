using Persistence.EfCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
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
        None,
        Vegan,
        Meat,
        Beverages
    }

    public class MenuAgg
    {
        public int RestaurantId { get; set; }
        public String Name { get; set; }
        public MenuType MenuType { get; set; }
        public MenuVisibilityTypes MenuVisibilityTypes { get; set; }

        public Menu Menu { get; private set; }
        public ICollection<MenuItem> MenuItems { get; set; }

        public MenuAgg(Menu menu)
        {
            Menu = menu;
        }
    }
}