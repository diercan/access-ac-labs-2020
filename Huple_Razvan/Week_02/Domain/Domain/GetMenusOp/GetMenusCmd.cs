using Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Domain.GetMenusOp
{
    public struct GetMenusCmd
    {
        public Restaurant Restaurant { get; }
        public string Name { get; }

        public GetMenusCmd(Restaurant restaurant, string name)
        {
            Restaurant = restaurant;
            Name = name;
            Restaurant.Menus = new List<Menu>() { new Menu("burgers", MenuType.Meat) };
        }
    }
}
