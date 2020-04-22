using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
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
            UnknownError,
            RestaurantDoesNotExist
        };

        [Required(ErrorMessage = "The Name field cannot be empty")]
        public string Name { get; }

        public List<Menu> Menus { get; set; } = new List<Menu>();

        public List<Employee> Employees { get; set; } = new List<Employee>();

        public List<Order> Orders { get; set; } = new List<Order>();

        public Restaurant(string name)
        {
            Name = name;
        }
    }
}