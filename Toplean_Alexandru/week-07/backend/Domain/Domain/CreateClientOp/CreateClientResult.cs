using CSharp.Choices.Attributes;
using Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Domain.CreateClientOp
{
    [AsChoice]
    public static partial class CreateClientResult
    {
        public interface ICreateClientResult { }

        public class ClientCreated : ICreateClientResult
        {
            public ClientAgg ClientAgg { get; }

            public ClientCreated(ClientAgg client)
            {
                ClientAgg = client;
            }
        }

        public class ClientNotCreated : ICreateClientResult
        {
            public String Reason { get; }

            public ClientNotCreated(String Error)
            {
                Reason = Error;
            }
        }
    }
}