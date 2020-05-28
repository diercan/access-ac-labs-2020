using Persistence.EfCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

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