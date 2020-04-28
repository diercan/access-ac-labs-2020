using CSharp.Choices.Attributes;
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
            public PaymentRequested()
            {
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