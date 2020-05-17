using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Domain.Models
{
    public class MenuItem
    {
        [Required(ErrorMessage = "Name field is required")]
        public String Name;

        [Required(ErrorMessage = "Price field is required")]
        [Range(0, float.MaxValue, ErrorMessage = "The price cannot be negative")]
        public float Price;

        public String ImageData;

        public List<String> Alergens;

        [Required(ErrorMessage = "Ingredients field is required")]
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