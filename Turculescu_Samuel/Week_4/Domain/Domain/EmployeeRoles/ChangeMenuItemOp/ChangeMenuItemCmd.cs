using Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Domain.EmployeeRoles.ChangeMenuItemOp
{
    public struct ChangeMenuItemCmd
    {
        public MenuAgg Menu { get; }
        public int MenuItemId { get; }
        public MenuItemAgg NewMenuItem { get; }

        public ChangeMenuItemCmd(MenuAgg menu, int menuItemId, MenuItemAgg newMenuItem)
        {
            Menu = menu;
            MenuItemId = menuItemId;
            NewMenuItem = newMenuItem;
        }
    }
}
