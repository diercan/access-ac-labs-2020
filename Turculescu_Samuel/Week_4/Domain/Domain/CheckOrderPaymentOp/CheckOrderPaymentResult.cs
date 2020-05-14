using System;
using System.Collections.Generic;
using System.Text;
using CSharp.Choices.Attributes;
using Domain.Models;
using System.Threading.Tasks;

namespace Domain.Domain.CheckOrderPaymentOp
{
    [AsChoice]
    public static partial class CheckOrderPaymentResult
    {        
        public interface ICheckOrderPaymentResult { }

        public class CheckOrderPaymentStatus : ICheckOrderPaymentResult
        {
            public string PaymentStatus { get; }

            public CheckOrderPaymentStatus(string paymentStatus)
            {
                Console.WriteLine(paymentStatus);
                PaymentStatus = paymentStatus;
            }
        }
    }
}
