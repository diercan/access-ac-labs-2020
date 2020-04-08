using Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Domain.AddMenuItemOp
{
    public struct AddMenuItemCmd
    {
        public Menu Menu { get; }
        public MenuItem MenuItem { get; }

        public AddMenuItemCmd(MenuItem menuItem, Menu menu)
        {
            MenuItem = menuItem;
            Menu = menu;
        }
    }
}
