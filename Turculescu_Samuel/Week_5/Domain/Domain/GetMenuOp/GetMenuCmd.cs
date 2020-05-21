using Persistence.EfCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Domain.GetMenuOp
{
    public struct GetMenuCmd
    {
        public Menu Menu { get; }

        public GetMenuCmd(Menu menu)
        {
            Menu = menu;
        }
    }
}
