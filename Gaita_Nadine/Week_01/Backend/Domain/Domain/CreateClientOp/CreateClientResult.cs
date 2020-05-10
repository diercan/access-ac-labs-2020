using CSharp.Choices.Attributes;
using Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Domain.CreateClientOp
{
    [AsChoice]
    public static partial class CreateClientResult
    {
        public interface ICreateClientResult { };
        public class ClientCreated : ICreateClientResult
        {
            public Client Client { get; }
            public ClientCreated(Client client)
            {
                Client = client;
            }
        }
        public class ClientNotCreated : ICreateClientResult
        {
            public string Reason { get; }
            public ClientNotCreated(string reason)
            {
                Reason = reason;
            }
        }
    }
}
