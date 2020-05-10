using CSharp.Choices.Attributes;
using Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Domain.PlaceOrder
{
    [AsChoice]
    public static partial class PlaceOrderResult
    {
        public interface IPlaceOrderResult { };

        public class OrderPlaced : IPlaceOrderResult
        {
            public Order Order;
            public OrderPlaced(Order order)
            {
                Order = order;
            }
        }

        public class OrderNotPlaced : IPlaceOrderResult
        {
            public string Reason { get; }
            public OrderNotPlaced(string reason)
            {
                Reason = reason;
            }
        }
    }
}
