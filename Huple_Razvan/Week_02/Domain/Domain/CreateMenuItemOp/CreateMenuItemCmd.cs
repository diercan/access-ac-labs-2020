using System;
using System.Collections.Generic;
using System.Text;
using Domain.Models;

namespace Domain.Domain.CreateMenuItemOp
{

    public struct CreateMenuItemCmd
    {
        public Menu Menu { get; }
        public string Title { get; }
        public uint Price { get; }
        public List<string> Ingredients { get; }
        public CreateMenuItemCmd(Menu menu, string title, uint price, List<string> ingredients)
        {
            Menu = menu;
            Title = title;
            Price = price;
            Ingredients = ingredients;
        }
    }
}
