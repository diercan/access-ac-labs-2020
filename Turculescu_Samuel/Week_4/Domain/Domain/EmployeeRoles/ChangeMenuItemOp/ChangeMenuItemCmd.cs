using Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Domain.EmployeeRoles.ChangeMenuItemOp
{
    public struct ChangeMenuItemCmd
    {
        public Menu Menu { get; }
        public int MenuItemId { get; }
        public MenuItem NewMenuItem { get; }

        public ChangeMenuItemCmd(Menu menu, int menuItemId, MenuItem newMenuItem)
        {
            Menu = menu;
            MenuItemId = menuItemId;
            NewMenuItem = newMenuItem;
        }
    }
}
