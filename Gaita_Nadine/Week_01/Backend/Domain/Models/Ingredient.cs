using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Models
{
    public class Ingredient
    {
        public string Name { get; }
        public Ingredient(string name)
        {
            Name = name;
        }
    }

}
