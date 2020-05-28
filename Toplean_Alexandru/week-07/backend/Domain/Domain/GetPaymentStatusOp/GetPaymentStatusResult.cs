using System;
using System.Collections.Generic;
using System.Text;
using static Domain.Models.Cart;
using System.Threading.Tasks;
using CSharp.Choices.Attributes;

namespace Domain.Domain.GetPaymentStatusOp
{
    [AsChoice]
    public static partial class GetPaymentStatusResult
    {
        public interface IGetPaymentStatusResult { }

        public class PaymentStatusGot : IGetPaymentStatusResult
        {
            public String Status { get; }

            public PaymentStatusGot(String status)
            {
                Status = status;
            }
        }

        public class NoPaymentStatusGot : IGetPaymentStatusResult
        {
            public String Reason { get; }

            public NoPaymentStatusGot(String reason)
            {
                Reason = reason;
            }
        }
    }
}