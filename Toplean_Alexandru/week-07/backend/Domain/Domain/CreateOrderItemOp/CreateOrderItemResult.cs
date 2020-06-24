using CSharp.Choices.Attributes;
using Domain.Models;
using Persistence.EfCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Domain.CreateOrderItemOp
{
    [AsChoice]
    public static partial class CreateOrderItemResult
    {
        public interface ICreateOrderItemResult { }

        public class OrderItemCreated : ICreateOrderItemResult
        {
            public OrderItemAgg OrderItemAgg { get; }

            public OrderItemCreated(OrderItemAgg orderItems)
            {
                OrderItemAgg = orderItems;
            }
        }

        public class OrderItemNotCreated : ICreateOrderItemResult
        {
            public String Reason { get; }

            public OrderItemNotCreated(String reason)
            {
                Reason = reason;
            }
        }
    }
}