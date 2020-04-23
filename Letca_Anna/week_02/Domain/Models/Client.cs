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
            Cart.calculateSubtotal(menuItem);
            Console.WriteLine($"Cart of {Uid} client updated: " + Cart.ToString());
        }

    }
}
