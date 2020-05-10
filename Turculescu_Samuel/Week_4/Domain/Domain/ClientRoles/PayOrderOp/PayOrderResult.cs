using System;
using System.Collections.Generic;
using System.Text;
using CSharp.Choices.Attributes;
using Domain.Models;
using System.Threading.Tasks;

namespace Domain.Domain.ClientRoles.PayOrderOp
{
    [AsChoice]
    public static partial class PayOrderResult
    {
        public interface IPayOrderResult { }

        public class PayOrderStatus : IPayOrderResult
        {
            public string Reason { get; }

            public PayOrderStatus(string reason)
            {
                Reason = reason;
            }
        }
    }
}
