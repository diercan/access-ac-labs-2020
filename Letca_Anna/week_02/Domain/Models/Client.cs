using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Models
{
    public class Client
    {
        public string Name { get; }
        public string Uid { get; }
        public Cart Cart { get; } = new Cart();

        public Client(string uid, string name)
        {
            Uid = uid;
            Name = name;            
        }

        public void AddToCart(MenuItem menuItem)
        {
            Cart.MenuItems.Add(menuItem);
            Cart.CalculateSubtotal(menuItem);
            Console.WriteLine($"Cart of {Name} client updated: " + Cart.ToString());
        }

    }
}
