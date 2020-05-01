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

        //public Menu Menu { get; set; }
        public Menu Menu { get; set; }

        public List<Order> IncomingOrders { get; } = new List<Order>();
        public RestaurantAgg(Restaurant restaurant)
        {
            Restaurant = restaurant;
        }

        public override string ToString()
        {
            return Menu != null ? $"{Name}'s menu is : \n" + Menu.ToString() : Name;
        }

        public void AddToIncomingOrders(Order order)
        {
            IncomingOrders.Add(order);
            Console.WriteLine($"New order added to {Name} restaurant: " + order.ToString());
        }

        public override bool Equals(object obj)
        {
            return (!(obj is string restaurantName)) ? false :
            restaurantName.Equals(this.Name) ? true :
            false;
        }
    }
}
