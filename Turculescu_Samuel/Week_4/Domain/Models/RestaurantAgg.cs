using Persistence.EfCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Models
{
    public class RestaurantAgg
    {
        public Restaurant Restaurant { get; set; }

        public List<MenuAgg> Menus { get; set; } = new List<MenuAgg>(); // Menu for restaurant

        public List<Order> OrdersList { get; set; } = new List<Order>(); // List with orders of restaurant
        public uint OrderId; // OrderId represent an unique number for each order

        public List<Employee> EmployeesList { get; set; } = new List<Employee>();  // List with employees of restaurant

        public RestaurantAgg(Restaurant restaurant)
        {
            Restaurant = restaurant;
        }
    }
}
