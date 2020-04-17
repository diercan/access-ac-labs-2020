using Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Domain.GetMenusOp
{
    public struct GetMenusCmd
    {
        public List<Menu> Menus { get; }
        public Restaurant Restaurant { get; }

        public GetMenusCmd(Restaurant restaurant)
        {
            Restaurant = restaurant;
            Menus = restaurant.Menus;
        }

        // If there are no menus available in a restaurant it will return false. Otherwise will return true
        public bool IsValid() => Menus == null ? false : true;
    }
}