using System;
using System.Collections.Generic;
using System.Text;
using CSharp.Choices.Attributes;
using Domain.Models;
using System.Threading.Tasks;

namespace Domain.Domain.PayOrderOp
{
    [AsChoice]
    public static partial class PayOrderResult
    {
        public interface IPayOrderResult { }

        public class OrderPaid : IPayOrderResult
        {
            public OrderAgg Order { get; }

            public OrderPaid(string reason, OrderAgg order)
            {
                Console.WriteLine(reason);
                Order = order;
            }
        }

        public class OrderNotPaid : IPayOrderResult
        {
            public string Reason { get; }

            public OrderNotPaid(string reason)
            {
                Console.WriteLine(reason);
                Reason = reason;
            }
        }
    }
}
