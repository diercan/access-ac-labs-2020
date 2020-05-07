using CSharp.Choices.Attributes;
using Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Domain.RequestPaymentOp
{
    [AsChoice]
    public static partial class RequestPaymentResult
    {
        public interface IRequestPaymentResult { }

        public class PaymentRequested : IRequestPaymentResult
        {
            public ClientAgg ClientAgg { get; }

            public PaymentRequested(ClientAgg client)
            {
                ClientAgg = client;
            }
        }

        public class PaymentNotRequested : IRequestPaymentResult
        {
            public String Reason;

            public PaymentNotRequested(String Error)
            {
                Reason = Error;
            }
        }
    }
}