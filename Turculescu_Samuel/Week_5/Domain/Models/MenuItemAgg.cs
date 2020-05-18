using System;
using System.Collections.Generic;
using System.Text;
using Persistence.EfCore;

namespace Domain.Models
{
    public class MenuItemAgg
    {
        public MenuItem MenuItem { get; set; }

        public MenuItemAgg(MenuItem menuItem) 
        {
            MenuItem = menuItem;
        }
    }
}