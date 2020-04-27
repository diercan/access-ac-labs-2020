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
            public Client Client;
            public ClientCreated(Client client)
            {
                Client = client;
            }
        }
    }
}
