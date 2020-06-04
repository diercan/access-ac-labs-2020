using Domain.Models;
using Persistence.EfCore;
using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Text;

namespace Domain.Domain.CreateMenuItemOp
{
    public struct CreateMenuItemCmd
    {
        public Menu Menu { get; }
        public string Name { get; }
        public string Ingredients { get; }
        public string Allergens { get; }
        public uint TotalQuantity { get; }
        public decimal Price { get; }
        public bool Availability { get; }        

        public CreateMenuItemCmd(Menu menu, string name, string ingredients, string allergens, uint totalQuantity, decimal price, bool availability)
        {
            Menu = menu;
            Name = name;
            Ingredients = ingredients;
            Allergens = allergens;
            TotalQuantity = totalQuantity;
            Price = price;
            Availability = availability;            
        }
    }
}
