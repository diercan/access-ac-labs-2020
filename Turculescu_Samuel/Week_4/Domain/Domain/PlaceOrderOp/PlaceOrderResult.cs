using CSharp.Choices.Attributes;
using Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Domain.PlaceOrderOp
{
    [AsChoice]
    public static partial class PlaceOrderResult
    {        
        public interface IPlaceOrderResult { }

        public class OrderPlaced : IPlaceOrderResult
        {
            public OrderAgg Order { get; }

            public OrderPlaced(OrderAgg order)
            {
                Order = order;
            }
        }

        public class OrderNotPlaced : IPlaceOrderResult
        {
            public string Reason { get; }

            public OrderNotPlaced(string  reason)
            {
                Console.WriteLine(reason);
                Reason = reason;
            }
        }
    }
}
