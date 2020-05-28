using Persistence.EfCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Domain.UpdateClientOp
{
    public class UpdateClientCmd
    {
        public Client Client { get; }

        public UpdateClientCmd(Client client)
        {
            Client = client;
        }
    }
}