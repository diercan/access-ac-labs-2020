using Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Domain.GetMenusOp
{
    public struct GetMenusCmd
    {
        public Restaurant Restaurant { get; }
        public Menu Menu { get; }

        public GetMenusCmd(Restaurant restaurant, Menu menu)
        {
            Restaurant = restaurant;
            Menu = menu;
        }
    }
}
