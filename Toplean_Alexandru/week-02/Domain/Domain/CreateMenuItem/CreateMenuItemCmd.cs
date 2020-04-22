using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Domain.Domain.CreateMenuItem
{
    public struct CreateMenuItemCmd
    {
        public String Name;
        public float Price;
        public String ImageData;
        public List<String> Alergens;
        public List<String> Ingredients;
        public Menu Menu;

        public CreateMenuItemCmd(String name, float price, List<String> alergens, List<String> ingredients, String imageData, Menu menu)
        {
            Name = name;
            Price = price;
            ImageData = imageData;
            Alergens = alergens;
            Ingredients = ingredients;
            Menu = menu;
        }

        public (bool, String) IsValid()
        {
            try
            {
                // Ingredients are mandatory
                if (Ingredients == null)
                    return (false, "Ingredients cannot be empty");

                // Ingredients are mandatory
                if (Ingredients.Count == 0)
                    return (false, "Ingredients cannot be empty");

                // No illegal characters
                if (HasIllegalCharacters(Name))
                    return (false, "Name field cannot have illegal characters");

                // A menu must be provided
                if (Menu == null)
                    return (false, "No menu provided");
                return (true, "None");
            }
            catch (Exception exp)
            {
                // Safety net. Returns the exception if occurs
                return (false, exp.ToString());
            }
        }

        public bool HasIllegalCharacters(String name) => name.Any(c => (int)c < 0x20 || (int)c > 0x7E);
    }
}