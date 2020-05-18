using System;
using System.Collections.Generic;
using System.Text;
using CSharp.Choices.Attributes;
using Domain.Models;
using System.Threading.Tasks;

namespace Domain.Domain.CreateClientOp
{
    [AsChoice]
    public static partial class CreateClientResult
    {
        public interface ICreateClientResult { }

        public class ClientCreated : ICreateClientResult
        {
            public ClientAgg Client { get; }

            public ClientCreated(ClientAgg client)
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
