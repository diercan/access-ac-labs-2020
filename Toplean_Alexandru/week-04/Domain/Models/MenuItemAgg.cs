using Persistence.EfCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Domain.Models
{
    public class MenuItemAgg
    {
        public ICollection<MenuItem> MenuItems { get; set; }
        public Menu Menu { get; set; }

        public MenuItemAgg(Restaurant restaurant, Menu menu)
        {
            Menu = menu;
        }
    }
}