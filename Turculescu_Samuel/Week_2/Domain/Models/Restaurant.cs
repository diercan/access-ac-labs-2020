using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Models
{
    public class Restaurant
    {
        public string Name { get; }
        public string Address { get; }

        public Menu Menu { get; set; }  // Menu for restaurant
        
        public Restaurant(string name, string address)
        {
            Name = name;
            Address = address;
        }
    }
}
