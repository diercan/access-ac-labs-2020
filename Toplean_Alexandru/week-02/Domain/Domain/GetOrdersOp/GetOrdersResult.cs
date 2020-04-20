using CSharp.Choices.Attributes;
using Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Domain.GetOrdersOp
{
    [AsChoice]
    public static partial class GetOrdersResult
    {
        public interface IGetOrdersResult { }

        public class OrdersGot : IGetOrdersResult
        {
            public List<Order> Orders { get; }

            public OrdersGot(List<Order> orders)
            {
                Orders = orders;
            }
        }

        public class NoOrdersGot : IGetOrdersResult
        {
            public String Reason { get; }

            public NoOrdersGot(String Reason)
            {
                this.Reason = Reason;
            }
        }
    }
}