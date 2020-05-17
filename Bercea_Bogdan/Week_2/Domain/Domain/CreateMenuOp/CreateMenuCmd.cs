using System;
using System.Collections.Generic;
using System.Text;
using Domain.Models;

namespace Domain.Domain.CreateMenuOp
{
    public struct CreateMenuCmd
    {
        public Restaurant Restaurant { get; }
        public string Name { get; }

        public MenuType MenuType { get; }

        public CreateMenuCmd(Restaurant restaurant, string name, MenuType menuType)
        {
            Restaurant = restaurant;
            Name = name;
            MenuType = menuType;
        }
    }
}
