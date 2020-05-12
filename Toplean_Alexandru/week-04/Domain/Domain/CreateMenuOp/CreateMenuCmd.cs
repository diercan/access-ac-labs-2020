using Domain.Models;
using Persistence.EfCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Domain.CreateMenuOp
{
    public struct CreateMenuCmd
    {
        public Menu Menu { get; }

        public CreateMenuCmd(Menu menu)
        {
            Menu = menu;
        }
    }
}