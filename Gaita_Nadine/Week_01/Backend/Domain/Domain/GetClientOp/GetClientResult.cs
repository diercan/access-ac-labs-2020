using CSharp.Choices.Attributes;
using Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Domain.GetClientOp
{
    [AsChoice]
    public static partial class GetClientResult
    {
        public interface IGetClientResult { }
        public class ClientFound : IGetClientResult
        {
            public Client Client { get; }

            public ClientFound(Client client)
            {
                Client = client;
            }
        }


        public class ClientNotFound : IGetClientResult
        {
            public string Reason { get; }

            public ClientNotFound(string reason)
            {
                Reason = reason;
            }
        }
    }
}
