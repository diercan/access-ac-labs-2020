using CSharp.Choices.Attributes;
using Domain.Models;
using System;
using System.Threading.Tasks;

namespace Domain.Domain.GetClientOp
{
    [AsChoice]
    public static partial class GetClientResult
    {
        public interface IGetClientResult{ }

        public class ClientFound : IGetClientResult
        {
            public string Name;

            public ClientFound(string name)
            {
                Name = name;
                Console.WriteLine("Client " + name + " found");
            }
        }
        public class ClientNotFound : IGetClientResult
        {
            public string Reason;

            public ClientNotFound(string reason)
            {
                Reason = reason;
                Console.WriteLine(Reason);
            }
        }
    }
}