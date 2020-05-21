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
            public OrderAgg Order { get; }

            public PaymentOrderStatus(OrderAgg order)
            {
                Order = order;
            }
        }
    }
}
