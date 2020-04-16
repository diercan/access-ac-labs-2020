using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Models
{
    public class Client
    {
        public string Uid { get; }
        public Cart Cart { get; } = new Cart();

        public Client(string uid)
        {
            Uid = uid;
        }

        public void AddToCart(MenuItem menuItem)
        {
            Cart.MenuItems.Add(menuItem);
            Cart.calculateSubtotal(menuItem);
            Console.WriteLine($"Cart of {Uid} client updated: " + Cart.ToString());
        }

    }
}
