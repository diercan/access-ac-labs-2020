using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Domain.CreateRestaurantOp
{
    public struct CreateRestaurantCmd
    {
        public string Name { get; }
        public string Address { get; }

        public CreateRestaurantCmd(string name, string address)
        {
            Name = name;
            Address = address;
        }
    }
}
