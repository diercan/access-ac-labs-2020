using Persistence.EfCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Domain.CreateClientOp
{
    public struct CreateClientCmd
    {
        public Client Client { get; }

        public CreateClientCmd(Client client)
        {
            Client = client;
        }

        //public String Name { get; }
        //public String Username { get; }
        //public String Password { get; }
        //public String Email { get; }

        //public CreateClientCmd(String name, String username, String password, String email)
        //{
        //    Name = name;
        //    Username = username;
        //    Password = password;
        //    Email = email;
        //}

        public (bool, String) IsValid()
        {
            return (true, "None");
        }
    }
}