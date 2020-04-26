using Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Domain.CreateClientOp
{
    public class CreateClientCmd
    {
        public string Name { get; }
        public List<Client> Clients { get; }
        public CreateClientCmd(List<Client> clients, string name)
        {
            Name = name;
            Clients = clients;
        }
    }
}
