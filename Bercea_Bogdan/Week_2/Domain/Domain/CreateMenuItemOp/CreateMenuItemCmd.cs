using Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Domain.CreateMenuItemOp
{
    public struct CreateMenuItemCmd
    {
        public string ItemName { get; }
        public decimal ItemPrice { get; }
        public List<string> Ingredients { get; }
        public List<string> Alergens { get; }
        public Menu Menu { get; }

        public CreateMenuItemCmd(string itemName, decimal price, List<string> ingredients,
            List<string> alergens, Menu menu)
        {
            ItemName = itemName;
            ItemPrice = price;
            Ingredients = ingredients;
            Alergens = alergens;
            Menu = menu;
        }
    }
}
