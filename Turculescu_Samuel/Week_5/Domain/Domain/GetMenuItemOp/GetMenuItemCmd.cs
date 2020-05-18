using Persistence.EfCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Domain.GetMenuItemOp
{
    public struct GetMenuItemCmd
    {
        public MenuItem MenuItem { get; }

        public GetMenuItemCmd(MenuItem menuItem)
        {
            MenuItem = menuItem;
        }
    }
}
