using System;
using System.Collections.Generic;
using System.Text;
using Domain.Models;

namespace Domain.Domain.EmployeeRoles.CreateMenuOp
{
    public struct CreateMenuCmd
    {
        public RestaurantAgg Restaurant { get; }
        public string MenuName { get; }

        public CreateMenuCmd(RestaurantAgg restaurant, string menuName)
        {
            Restaurant = restaurant;
            MenuName = menuName;           
        }
    }
}
