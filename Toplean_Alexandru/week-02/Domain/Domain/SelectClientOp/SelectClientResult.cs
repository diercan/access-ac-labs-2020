using CSharp.Choices.Attributes;
using Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Domain.SelectClientOp
{
    [AsChoice]
    public static partial class SelectClientResult
    {
        public interface ISelectClientResult { }

        public class ClientSelected : ISelectClientResult
        {
            public Client Client;

            public ClientSelected(Client client)
            {
                Client = client;
            }
        }

        public class ClientNotSelected : ISelectClientResult
        {
            private String Reason;

            public ClientNotSelected(String reason)
            {
                Reason = reason;
            }
        }
    }
}