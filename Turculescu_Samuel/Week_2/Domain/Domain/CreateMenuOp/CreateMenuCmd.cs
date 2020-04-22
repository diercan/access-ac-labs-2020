using System;
using System.Collections.Generic;
using System.Text;
using Domain.Models;

namespace Domain.Domain.CreateMenuOp
{
    public struct CreateMenuCmd
    {
        public Restaurant Restaurant { get; }
        public string MenuName { get; }

        public CreateMenuCmd(Restaurant restaurant, string menuName)
        {
            Restaurant = restaurant;
            MenuName = menuName;
        }
    }
}
