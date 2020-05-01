using Persistence.EfCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Models
{
    public class RestaurantAgg
    {
        public Restaurant Restaurant { get; }
        public string Name { get; }

        public Menus Menu { get; set; }

        //public List<Employees> employees { get; } = new List<Employees>();

        //public List<Order> IncomingOrders { get; } = new List<Order>();

        public RestaurantAgg(Restaurant restaurant)
        {
            Restaurant = restaurant;
        }

        public override string ToString()
        {
            return Menu != null ? $"{Name}'s menu is : \n" + Menu.ToString() : Name;
        }

        //public void AddToIncomingOrders(Order order)
        //{
        //    IncomingOrders.Add(order);
        //    Console.WriteLine($"New order added to {Name} restaurant: " + order.ToString());
        //}

    }
}
