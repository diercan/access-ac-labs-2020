using System;
using System.Collections.Generic;
using System.Text;
using CSharp.Choices.Attributes;
using Domain.Models;
using System.Threading.Tasks;


namespace Domain.Domain.EmployeeRoles.CreatePaymentRequestOp
{
    [AsChoice]
    public static partial class CreatePaymentRequestResult
    {
        public interface ICreatePaymentRequestResult { }

        public class PaymentRequestCreated : ICreatePaymentRequestResult
        {
            public PaymentStatus PaymentStatus { get; }

            public PaymentRequestCreated(PaymentStatus paymentStatus)
            {
                PaymentStatus = paymentStatus;
            }
        }

        public class PaymentRequestNotCreated : ICreatePaymentRequestResult
        {
            public string Reason { get; }

            public PaymentRequestNotCreated(string reason)
            {
                Reason = reason;
            }
        }
    }
}
