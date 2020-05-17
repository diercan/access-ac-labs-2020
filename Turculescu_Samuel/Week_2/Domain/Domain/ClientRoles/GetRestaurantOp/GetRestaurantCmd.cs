using System;
using System.Collections.Generic;
using System.Text;
using Domain.Models;

namespace Domain.Domain.ClientRoles.GetRestaurantOp
{
    public struct GetRestaurantCmd
    {
        public string Name { get; }

        public GetRestaurantCmd(string name)
        {
            Name = name;
        }
    }
}
