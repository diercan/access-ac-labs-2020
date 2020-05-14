using System;
using System.Collections.Generic;
using System.Text;
using CSharp.Choices.Attributes;
using Domain.Models;
using System.Threading.Tasks;

namespace Domain.Domain.ChangeQuantityOp
{
    [AsChoice]
    public static partial class ChangeQuantityResult
    {
        public interface IChangeQuantityResult { }

        public class QuantityChanged : IChangeQuantityResult
        {
            public OrderItemAgg NewOrderItem { get; }
            public QuantityChanged(OrderItemAgg orderItem)
            {
                NewOrderItem = orderItem;
            }
        }

        public class QuantityNotChanged : IChangeQuantityResult
        {
            public string Reason { get; }
            
            public QuantityNotChanged(string reason)
            {
                Reason = reason;
            }
        }
    }
}
