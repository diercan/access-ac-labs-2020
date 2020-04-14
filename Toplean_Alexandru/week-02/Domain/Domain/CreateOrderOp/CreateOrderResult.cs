using CSharp.Choices.Attributes;
using Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;
using static Domain.Models.Order;

namespace Domain.Domain.CreateOrderOp
{
    [AsChoice]
    public static partial class CreateOrderResult
    {
        public interface ICreateOrderResult { }

        public class OrderCreated : ICreateOrderResult
        {
            public Order Order { get; }
            public Restaurant Restaurant { get; }

            public OrderCreated(Order order, Restaurant restaurant)
            {
                Order = order;
                Restaurant = restaurant;
            }
        }

        public class OrderNotCreated : ICreateOrderResult
        {
            public String Reason;

            public OrderNotCreated(String error)
            {
                Reason = error;
            }
        }
    }
}