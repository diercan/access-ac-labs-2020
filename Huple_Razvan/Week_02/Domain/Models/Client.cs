using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Models
{
    public class Client
    {
        public string Name { get; }

        public string Id { get; }

        public Client( string name, string id)
        {
            Name = name;
            Id = id;
        }
    }
}
