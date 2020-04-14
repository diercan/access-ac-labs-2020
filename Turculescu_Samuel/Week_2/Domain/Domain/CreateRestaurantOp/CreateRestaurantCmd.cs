using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Domain.CreateRestaurantOp
{
    public struct CreateRestaurantCmd
    {
        public string Name { get; }

        public CreateRestaurantCmd(string name)
        {
            Name = name;
        }
    }
}
