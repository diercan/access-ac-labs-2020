using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Models
{
    public class Restaurant
    {
        public string Name { get; }
        public List<Menu> Menu { get; set; }
        public Restaurant(string name)
        {
            Name = name;
        }
    }
}
