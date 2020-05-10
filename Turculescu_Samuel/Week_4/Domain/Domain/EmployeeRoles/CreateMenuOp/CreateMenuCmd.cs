using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Domain.EmployeeRoles.CreateMenuOp
{
    public struct CreateMenuCmd
    {
        public string Name { get; }
        public int RestaurantId { get; }

        public CreateMenuCmd(string name, int restaurantId)
        {
            Name = name;
            RestaurantId = restaurantId;
        }
    }
}
