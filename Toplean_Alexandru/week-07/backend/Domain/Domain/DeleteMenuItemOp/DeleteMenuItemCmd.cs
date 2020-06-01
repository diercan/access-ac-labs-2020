using Persistence.EfCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Domain.DeleteMenuItemOp
{
    public class DeleteMenuItemCmd
    {
        public MenuItem MenuItem { get; }

        public DeleteMenuItemCmd(MenuItem item)
        {
            MenuItem = item;
        }
    }
}