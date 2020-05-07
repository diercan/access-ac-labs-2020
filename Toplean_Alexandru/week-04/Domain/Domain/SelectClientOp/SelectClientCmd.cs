using Persistence.EfCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Domain.SelectClientOp
{
    public class SelectClientCmd
    {
        public Client Client { get; }

        public SelectClientCmd(Client client)
        {
            Client = client;
        }

        public void CheckIfValid()
        {
            if (Client == null)
                throw new Exception("The client does not exist");
        }
    }
}