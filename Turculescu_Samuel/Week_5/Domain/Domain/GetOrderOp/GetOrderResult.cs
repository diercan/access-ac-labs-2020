using System;
using System.Collections.Generic;
using System.Text;
using CSharp.Choices.Attributes;
using Domain.Models;
using System.Threading.Tasks;

namespace Domain.Domain.GetOrderOp
{
    [AsChoice]
    public static partial class GetOrderResult
    {
        public interface IGetOrderResult { }

        public class OrderFound : IGetOrderResult
        {
            public OrderAgg Agg { get; }

            public OrderFound(OrderAgg agg)
            {
                Agg = agg;
            }
        }

        public class OrderNotFound : IGetOrderResult
        {
            public string Reason { get; }

            public OrderNotFound(string reason)
            {
                Console.WriteLine(reason);
                Reason = reason;
            }
        }
    }
}
