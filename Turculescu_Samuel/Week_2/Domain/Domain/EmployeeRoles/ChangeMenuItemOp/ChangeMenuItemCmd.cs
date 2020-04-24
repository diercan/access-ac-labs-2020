using Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Domain.EmployeeRoles.ChangeMenuItemOp
{
    public struct ChangeMenuItemCmd
    {
        public MenuItem CurrentMenuItem { get; }
        public MenuItem NewMenuItem { get; }

        public ChangeMenuItemCmd(MenuItem currentMenuItem, MenuItem newMenuItem)
        {
            CurrentMenuItem = currentMenuItem;
            NewMenuItem = newMenuItem;
        }
    }
}
