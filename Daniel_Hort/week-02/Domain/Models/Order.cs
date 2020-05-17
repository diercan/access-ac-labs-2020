using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace Domain.Models
{
    public class Order
    {
        public List<(MenuItem, uint)> Items { get; }
        public float TotalPrice => Items.Sum(a => a.Item1.Price * a.Item2);
        public Client Client { get; }
        public Order(Client client)
        {
            Items = new List<(MenuItem, uint)>();
            Client = client;
        }
    }
}
