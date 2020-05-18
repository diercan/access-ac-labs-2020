using Domain.Models;
using Persistence.EfCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Domain.ChangeMenuItemOp
{
    public struct ChangeMenuItemCmd
    {
        public MenuItem MenuItem { get; set; }
        public MenuItem NewMenuItem { get; }

        public ChangeMenuItemCmd(MenuItem menuItem, MenuItem newMenuItem)
        {
            MenuItem = menuItem;
            NewMenuItem = newMenuItem;
        }
    }
}
