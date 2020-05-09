using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Models
{
    public class Restaurant
    {
        private Restaurant restaurant;

        public string Name { get; }
        public Menu Menu { get; set; }
        public Restaurant(string name)
        {
            Name = name;
        }

    }
}
