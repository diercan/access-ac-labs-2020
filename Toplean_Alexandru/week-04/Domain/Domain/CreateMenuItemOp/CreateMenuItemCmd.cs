using Domain.Models;
using Persistence.EfCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Domain.CreateMenuItemOp
{
    public struct CreateMenuItemCmd
    {
        public MenuItem MenuItem { get; }

        public CreateMenuItemCmd(MenuItem menuItem)
        {
            MenuItem = menuItem;
        }
    }
}