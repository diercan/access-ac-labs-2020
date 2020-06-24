using Persistence.EfCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Domain.UpdateMenuItemOp
{
    public class UpdateMenuItemCmd
    {
        public MenuItem MenuItem { get; }

        public UpdateMenuItemCmd(MenuItem item)
        {
            MenuItem = item;
        }
    }
}