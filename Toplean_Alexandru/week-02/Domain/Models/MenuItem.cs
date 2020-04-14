using System;
using System.Collections.Generic;

namespace Domain.Models
{
    public class MenuItem
    {
        public String Name;
        public float Price;
        public String ImageData;
        public List<String> Alergens;
        public List<String> Ingredients;

        public MenuItem(String name, float price, List<String> alergens, List<String> ingredients, String imageData)
        {
            Name = name;
            Price = price;
            ImageData = imageData;
            Alergens = alergens;
            Ingredients = ingredients;
        }
    }
}