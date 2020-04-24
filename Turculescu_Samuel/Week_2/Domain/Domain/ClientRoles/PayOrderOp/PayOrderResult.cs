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

        public class PayOrderSuccessful : IPayOrderResult 
        {
            public PaymentStatus PaymentStatus { get; }

            public PayOrderSuccessful(PaymentStatus paymentStatus)
            {
                PaymentStatus = paymentStatus;
            }
        }

        public class PayOrderNotSuccessful : IPayOrderResult
        {
            public string Reason { get; }

            public PayOrderNotSuccessful(string reason)
            {
                Reason = reason;
            }
        }
    }
}
