using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Models
{
    public class Restaurant
    {
        public string Name { get; }
        public Menu Menu { get; set; }
        public Restaurant(string name)
        {
            Name = name;
        }

        public override string ToString()
        {
            return $"{Name}'s menu is : \n" + Menu.ToString();
        }
    }
}
