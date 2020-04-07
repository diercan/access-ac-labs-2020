using Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Domain.CreateMenuItemOp
{
    
    public struct CreateMenuItemCmd
    {
        public Menu Menu { get; }
        public string Name { get; }
        public double Price { get; }

        public CreateMenuItemCmd(Menu menu, string name, double price)
        {
            Menu = menu;
            Name = name;
            Price = price;
        }
    }
}
