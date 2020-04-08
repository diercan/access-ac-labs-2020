using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Models
{
    public class Restaurant
    {
        public enum RestaurantErrorCode
        {
            None,
            RestaurantExists,
            IllegalCharacters,
            NameTooLong,
            EmptyField,
            UnknownError
        };

        public string Name { get; }
        public Menu Menu { get; set; }

        public List<Employee> Employees { get; set; }

        public Restaurant(string name)
        {
            Name = name;
        }
    }
}