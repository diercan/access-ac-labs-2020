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
        public string Password { get; }
        public Cart Cart { get; } = new Cart();
        public Client(string name, string email, string uid, string password)
        {
            Name = name;
            Email = email;
            Uid = uid;
            Password = password;
        }

        public Client(string uid)
        {
            Uid = uid;
        }
    }
}
