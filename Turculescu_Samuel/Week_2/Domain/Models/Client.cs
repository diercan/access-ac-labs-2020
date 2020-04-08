using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Models
{
    public class Client
    {
        public string Name { get; }
        public Order Order { get; set; }
        public Client(string name)
        {
            Name = name;
        }
    }
}
