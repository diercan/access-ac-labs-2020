using CSharp.Choices.Attributes;
using Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Domain.CreateOrderOp
{
    [AsChoice]
    public static partial class CreateOrderResult
    {
        public interface ICreateOrderResult { }

        public class OrderCreated : ICreateOrderResult
        {
            public Order Order { get; }

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
