using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Models
{
    public class Client
    {
        public string Name { get; }

        public Client(string name)
        {
            Name = name;
        }
    }
}
