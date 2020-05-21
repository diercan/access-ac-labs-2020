using System;
using System.Collections.Generic;
using System.Text;
using CSharp.Choices.Attributes;
using Domain.Models;
using System.Threading.Tasks;

namespace Domain.Domain.CreateOrderItemOp
{
    [AsChoice]
    public static partial class CreateOrderItemResult
    {
        public interface ICreateOrderItemResult { }

        public class OrderItemCreated : ICreateOrderItemResult
        {
            public OrderItemAgg OrderItem { get; }

            public OrderItemCreated(OrderItemAgg orderItem)
            {
                OrderItem = orderItem;
            }
        }

        public class OrderItemNotCreated : ICreateOrderItemResult
        {
            public string Reason { get; }

            public OrderItemNotCreated(string reason)
            {
                Reason = reason;
            }
        }
    }
}
