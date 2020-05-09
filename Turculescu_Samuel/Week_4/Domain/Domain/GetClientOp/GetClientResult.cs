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

        public class ClientFound : IGetClientResult
        {
            public ClientAgg Agg { get; }

            public ClientFound(ClientAgg agg)
            {
                Agg = agg;
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
