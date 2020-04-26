using Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Domain.GetClientOp
{
    public struct GetClientCmd
    {
        public string Name { get; }
        public List<Client> Clients { get;}

        public GetClientCmd(string name)
        {
            Name = name;
            Clients = new List<Client>();
        }
    }
}
