using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Models
{
    public class Client
    {
        public string Name { get; }
        public string Email { get; }
        public string Uid { get; }
        public Client(string name, string email, string uid)
        {
            Name = name;
            Email = email;
            Uid = uid;
        }

        public Client(string uid)
        {
            Uid = uid;
        }
    }
}
