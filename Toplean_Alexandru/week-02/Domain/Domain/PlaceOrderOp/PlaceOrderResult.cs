using CSharp.Choices.Attributes;
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
            public OrderPlaced()
            {
            }
        }

        public class OrderNotPlaced : IPlaceOrderResult
        {
            public String Reason { get; }

            public OrderNotPlaced(String reason)
            {
                Reason = reason;
            }
        }
    }
}