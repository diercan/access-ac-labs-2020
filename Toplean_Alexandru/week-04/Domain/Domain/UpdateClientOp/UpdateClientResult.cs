using CSharp.Choices.Attributes;
using Domain.Models;
using Persistence.EfCore;
using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Text;

namespace Domain.Domain.UpdateClientOp
{
    [AsChoice]
    public static partial class UpdateClientResult
    {
        public interface IUpdateClientResult { }

        public class ClientUpdated : IUpdateClientResult
        {
            public ClientAgg ClientAgg { get; }

            public ClientUpdated(ClientAgg client)
            {
                ClientAgg = client;
            }
        }

        public class ClientNotUpdated : IUpdateClientResult
        {
            public String Reason { get; }

            public ClientNotUpdated(String reason)
            {
                Reason = reason;
            }
        }
    }
}