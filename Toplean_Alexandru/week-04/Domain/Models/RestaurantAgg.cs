using Persistence.EfCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;

namespace Domain.Models
{
    public class RestaurantAgg
    {
        public string Name { get; private set; }

        public Restaurant Restaurant { get; }

        public ICollection<Menu> Menus { get; set; }

        public ICollection<Employee> Employees { get; set; }

        public ICollection<Order> Orders { get; set; }

        public RestaurantAgg(Restaurant restaurant)
        {
            Restaurant = restaurant;
            CreateModelFromDB();
        }

        public void CreateModelFromDB()
        {
            this.Name = Restaurant.Name;
            this.Menus = Restaurant.Menu;
            this.Employees = Restaurant.Employee;
            this.Orders = Restaurant.Order;
        }
    }
}