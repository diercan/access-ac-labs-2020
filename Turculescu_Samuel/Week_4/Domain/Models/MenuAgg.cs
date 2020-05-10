using Persistence.EfCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Models
{
    public class MenuAgg
    {
        public Menu Menu { get; }
        public List<MenuItemAgg> MenuItems { get; set; } = new List<MenuItemAgg>();

        public MenuAgg(Menu menu)
        {
            Menu = menu;
        }
    }
}
