using Domain.Models;
using Persistence.EfCore;
using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Text;

namespace Domain.Domain.EmployeeRoles.CreateMenuItemOp
{
    public struct CreateMenuItemCmd
    {
        public string Name { get; }
        public string Ingredients { get; }
        public string Allergens { get; }
        public uint TotalQuantity { get; }
        public double Price { get; }
        public bool Availability { get; }
        public int MenuId { get; }

        public CreateMenuItemCmd(string name, string ingredients, string allergens, uint totalQuantity, double price, bool availability, int menuId)
        {            
            Name = name;
            Ingredients = ingredients;
            Allergens = allergens;
            TotalQuantity = totalQuantity;
            Price = price;
            Availability = availability;
            MenuId = menuId;
        }
    }
}
