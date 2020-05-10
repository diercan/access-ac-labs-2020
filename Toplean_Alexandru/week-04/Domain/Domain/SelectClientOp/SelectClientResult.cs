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
            public ClientAgg ClientAgg { get; }

            public ClientSelected(ClientAgg client)
            {
                ClientAgg = client;
            }
        }

        public class ClientNotSelected : ISelectClientResult
        {
            public String Reason { get; }

            public ClientNotSelected(String reason)
            {
                Reason = reason;
            }
        }
    }
}