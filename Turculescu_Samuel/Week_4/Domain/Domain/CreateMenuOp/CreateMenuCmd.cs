using Persistence.EfCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Domain.CreateMenuOp
{
    public struct CreateMenuCmd
    {
        public string MenuName { get; }
        public Restaurant Restaurant { get; }

        public CreateMenuCmd(string menuName, Restaurant restaurant)
        {
            MenuName = menuName;
            Restaurant = restaurant;
        }
    }
}
