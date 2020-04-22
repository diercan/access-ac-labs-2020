using System.Security.Cryptography.X509Certificates;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Models
{
    public class MenuItem
    {
        public string Name { get; }
        public float Price { get; }
        public int Quantity { get; }
        public string Ingredients { get; }
        public string Allergens { get; }

        public MenuItem(string name, float price, int quantity, string ingredients, string allergens) 
        {
            Name = name;
            Price = price;
            Quantity = quantity;
            Ingredients = ingredients;
            Allergens = allergens;
        }
    }
}