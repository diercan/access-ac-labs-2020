using Persistence.EfCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Domain.GetMenuItemsOp
{
    public struct GetMenuItemsCmd
    {
        public List<MenuItem> MenuItems { get; }

        public GetMenuItemsCmd(List<MenuItem> menuItems)
        {
            MenuItems = menuItems;
        }
    }
}
