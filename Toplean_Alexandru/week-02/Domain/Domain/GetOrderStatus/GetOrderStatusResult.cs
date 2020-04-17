using CSharp.Choices.Attributes;
using System;
using System.Collections.Generic;
using System.Text;
using static Domain.Models.Cart;

namespace Domain.Domain.GetOrderStatus
{
    [AsChoice]
    public static partial class GetOrderStatusResult
    {
        public interface IGetOrderStatusResult { }

        public class OrderGot : IGetOrderStatusResult
        {
            public CartStatus CartStatus { get; }

            public OrderGot(CartStatus status)
            {
                CartStatus = status;
            }
        }

        public class NoOrderGot : IGetOrderStatusResult
        {
            public String Reason { get; }

            public NoOrderGot(String reason)
            {
                Reason = reason;
            }
        }
    }
}