using Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Domain.CreateMenuItemOp
{
    class CreateMenuItemCmd
    {
        public Menu Menu { get; }
        public string Name { get; }
        public uint Price { get; }

        public CreateMenuItemCmd(Menu menu, string name, uint price)
        {
            Menu = menu;
            Name = name;
            Price = price;
        }
    }
}
