using System;
using System.Collections.Generic;
using System.Text;
using Domain.Models;

namespace Domain.Domain.CreateMenuOp
{
    public struct CreateMenuCmd
    {
        public Restaurant Restaurant { get; }
        public MenuType MenuType { get; }

        public CreateMenuCmd(Restaurant restaurant, MenuType menuType)
        {
            Restaurant = restaurant;
            MenuType = menuType;
        }
    }
}
