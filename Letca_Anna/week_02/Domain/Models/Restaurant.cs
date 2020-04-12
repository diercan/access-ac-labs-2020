using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Models
{
    public class Restaurant
    {
        public string Name { get; }
        public Menu Menu { get; set; }

        public List<Order> IncomingOrders { get; } = new List<Order>();
        public Restaurant(string name)
        {
            Name = name;
        }

        public override string ToString()
        {
            return $"{Name}'s menu is : \n" + Menu.ToString();
        }

        public void AddToIncomingOrders(Order order)
        {
            IncomingOrders.Add(order);
        }
    }
}
