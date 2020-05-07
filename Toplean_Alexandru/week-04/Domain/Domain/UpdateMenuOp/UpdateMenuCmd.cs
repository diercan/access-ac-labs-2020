using Persistence.EfCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Domain.UpdateMenuOp
{
    public struct UpdateMenuCmd
    {
        public Menu Menu { get; }

        public UpdateMenuCmd(Menu menu)
        {
            Menu = menu;
        }
    }
}