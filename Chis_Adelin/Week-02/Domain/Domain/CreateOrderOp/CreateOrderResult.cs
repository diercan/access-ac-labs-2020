using CSharp.Choices.Attributes;
using Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Domain.CreateOrderOp
{
    public static partial class CreateOrderResult
    {
        [AsChoice]
        public interface ICreateOrderResult { }
        public class OrderCreated : ICreateOrderResult
        {
            public Order Order;
            public OrderCreated(Order order)
            {
                Order = order;
            }
        }
        public class OrderNotCreated : ICreateOrderResult
        {
            public string Reason { get; }
            public OrderNotCreated(string reason)
            {
                Reason = reason;
            }
        }
    }
}
