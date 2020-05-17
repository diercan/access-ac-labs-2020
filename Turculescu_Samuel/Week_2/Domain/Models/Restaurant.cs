using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Models
{
    public class Restaurant
    {
        public string Name { get; }
        public string Address { get; }

        public List<Menu> Menus { get; set; } = new List<Menu>(); // Menu for restaurant

        public List<Order> OrdersList { get; set; } = new List<Order>(); // List with orders of restaurant
        public uint OrderId; // OrderId represent an unique number for each order

        public List<Employee> EmployeesList { get; set; } = new List<Employee>();  // List with employees of restaurant

        public Restaurant(string name, string address)
        {
            Name = name;
            Address = address;
            OrderId = 0;
        }
    }
}
