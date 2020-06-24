using System;
using System.Collections.Generic;
using System.Text;
using CSharp.Choices.Attributes;
using Domain.Models;
using System.Threading.Tasks;
using Persistence.EfCore;

namespace Domain.Domain.GetOrderItemsOp
{
    [AsChoice]
    public static partial class GetOrderItemsResult
    {
        public interface IGetOrderItemsResult { }

        public class OrderItemsFound : IGetOrderItemsResult
        {
            public List<OrderItem> OrderItems { get; }

            public OrderItemsFound(List<OrderItem> orderItems)
            {
                OrderItems = orderItems;
            }
        }

        public class OrderItemsNotFound : IGetOrderItemsResult
        {
            public string Reason { get; }

            public OrderItemsNotFound(string reason)
            {
                Console.WriteLine(reason);
                Reason = reason;
            }
        }
    }
}
