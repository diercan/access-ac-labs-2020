using System;
using CSharp.Choices.Attributes;
using Domain.Models;
using System.Threading.Tasks;
namespace Domain.Domain.CreateClientOp
{
    [AsChoice]
    public static partial class CreateClientResult
    {
        public interface ICreateClientResult{ }

        public class ClientCreated : ICreateClientResult
        {
            public Client Client;

            public ClientCreated(Client client)
            {
                Client = client;
                Console.WriteLine($"Client {Client.Name} created successfully");
            }
        }

        public class ClientNotCreated : ICreateClientResult
        {
            public string Reason { get; }

            public ClientNotCreated(string reason)
            {
                Reason = reason;
                Console.WriteLine("Client not created: " + Reason);
            }
        }
    }
}