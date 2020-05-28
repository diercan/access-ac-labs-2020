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
    }
}