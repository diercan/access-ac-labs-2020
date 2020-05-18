using System;
using System.Collections.Generic;
using System.Text;
using CSharp.Choices.Attributes;
using Domain.Models;
using System.Threading.Tasks;


namespace Domain.Domain.CreatePaymentRequestOp
{
    [AsChoice]
    public static partial class CreatePaymentRequestResult
    {
        public interface ICreatePaymentRequestResult { }

        public class PaymentOrderStatus : ICreatePaymentRequestResult
        {
            public string Reason { get; }

            public PaymentOrderStatus(string reason)
            {
                Reason = reason;
            }
        }
    }
}
