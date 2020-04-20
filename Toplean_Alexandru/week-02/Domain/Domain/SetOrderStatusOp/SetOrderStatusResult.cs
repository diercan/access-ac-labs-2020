using CSharp.Choices.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Domain.SetOrderStatusOp
{
    [AsChoice]
    public static partial class SetOrderStatusResult
    {
        public interface ISetOrderStatusResult { }

        public class OrderStatusSet : ISetOrderStatusResult
        {
            public OrderStatusSet()
            {
            }
        }

        public class OrderStatusNotSet : ISetOrderStatusResult
        {
            public String Reason { get; }

            public OrderStatusNotSet(String reason)
            {
                Reason = reason;
            }
        }
    }
}