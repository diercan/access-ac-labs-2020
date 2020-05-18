using System;
using System.Collections.Generic;
using System.Text;
using CSharp.Choices.Attributes;
using Domain.Models;
using System.Threading.Tasks;

namespace Domain.Domain.GetOrderItemOp
{
    [AsChoice]
    public static partial class GetOrderItemResult
    {
        public interface IGetOrderItemResult { }

        public class OrderItemFound : IGetOrderItemResult
        {
            public OrderItemAgg Agg { get; }

            public OrderItemFound(OrderItemAgg agg)
            {
                Agg = agg;
            }
        }

        public class OrderItemNotFound : IGetOrderItemResult
        {
            public string Reason { get; }

            public OrderItemNotFound(string reason)
            {
                Console.WriteLine(reason);
                Reason = reason;
            }
        }
    }
}
