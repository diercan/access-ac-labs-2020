using Persistence.EfCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Domain.Models
{
    [Table("Restaurants")]
    public class RestaurantAgg
    {
        [Required(ErrorMessage = "The Name field cannot be empty")]
        [Column("Name")]
        public string Name { get; }

        public Restaurant Restaurant { get; }
        public List<Menu> Menus { get; set; } = new List<Menu>();

        public List<Employee> Employees { get; set; } = new List<Employee>();

        public List<Order> Orders { get; set; } = new List<Order>();

        public RestaurantAgg(Restaurant restaurant)
        {
            Restaurant = restaurant;
        }
    }
}