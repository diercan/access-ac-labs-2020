using System;
using System.Collections.Generic;
using System.Text;
using CSharp.Choices.Attributes;
using Domain.Models;
using System.Threading.Tasks;

namespace Domain.Domain.GetClientOp
{
    [AsChoice]
    public static partial class GetClientResult
    {
        public interface IGetClientResult { }

        public class GetClientSuccessful : IGetClientResult
        {
            public ClientAgg Client { get; }

            public GetClientSuccessful(ClientAgg client)
            {
                Client = client;
            }
        }

        public class GetClientNotSuccessful : IGetClientResult
        {
            public string Reason { get; }

            public GetClientNotSuccessful(string reason)
            {
                Reason = reason;
            }
        }
    }
}
