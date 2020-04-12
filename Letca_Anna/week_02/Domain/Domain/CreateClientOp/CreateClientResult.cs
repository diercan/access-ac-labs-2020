using CSharp.Choices.Attributes;
using Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Domain.CreateClientOp
{
    public class CreateClientResult
    {
        [AsChoice]
        public interface ICreateClientResult { };

        public class ClientCreated : ICreateClientResult
        {
            Client Client;
            public ClientCreated(Client client)
            {
                Console.WriteLine("client created");
                Client = client;
            }
        }

        public class ClientNotCreated : ICreateClientResult
        {
            public string Reason { get; }
            public ClientNotCreated(string reason)
            {
                Reason = reason;
                Console.WriteLine(reason);
            }
        }
    }
}
