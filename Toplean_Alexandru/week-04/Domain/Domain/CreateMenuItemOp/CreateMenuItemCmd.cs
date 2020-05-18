using Domain.Models;
using Persistence.EfCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Domain.CreateMenuItemOp
{
    public struct CreateMenuItemCmd
    {
        public Menu Menu { get; }
        public MenuItem MenuItem { get; }

        public CreateMenuItemCmd(Menu menu, MenuItem menuItem)
        {
            Menu = menu;
            MenuItem = menuItem;
        }
    }
}