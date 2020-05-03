using System;
using System.Collections.Generic;
using System.Text;
using static Domain.Models.Cart;
using System.Threading.Tasks;

namespace Domain.Domain.GetPaymentStatusOp
{
    public static partial class GetPaymentStatusResult
    {
        public interface IGetPaymentStatusResult { }

        public class PaymentStatusGot : IGetPaymentStatusResult
        {
            public PaymentStatus Status { get; }

            public PaymentStatusGot(PaymentStatus status)
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