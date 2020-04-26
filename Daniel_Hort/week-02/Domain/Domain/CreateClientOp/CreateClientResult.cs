using Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Domain.CreateClientOp
{
    public class CreateClientResult
    {
        public interface ICreateClientResult { }

        public class ClientCreated : ICreateClientResult
        {
            public Client Client;
            public ClientCreated(Client client)
            {
                Client = client;
            }
        }
    }
}
