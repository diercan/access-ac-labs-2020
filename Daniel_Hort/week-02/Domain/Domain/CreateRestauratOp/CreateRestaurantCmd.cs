using Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Domain.CreateRestauratOp
{
    public class CreateRestaurantCmd
    {
        public string Name { get; }

        public CreateRestaurantCmd(string name)
        {
            Name = name;
        }
    }
}
