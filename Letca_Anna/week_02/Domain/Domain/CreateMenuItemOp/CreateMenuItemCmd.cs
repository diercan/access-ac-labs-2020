using Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Domain.CreateMenuItemOp
{
    
    public struct CreateMenuItemCmd
    {
        public string Name { get; }
        public double Price { get; }

        public CreateMenuItemCmd(string name, double price)
        {
            Name = name;
            Price = price;
        }
    }
}
