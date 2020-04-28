using Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Domain.EmployeeRoles.AddMenuItemOp
{
    public struct AddMenuItemCmd
    {
        public Menu Menu { get; }
        public MenuItem NewMenuItem { get; }

        public AddMenuItemCmd(Menu menu, MenuItem newMenuItem)
        {
            Menu = menu;
            NewMenuItem = newMenuItem;
        }
    }
}
