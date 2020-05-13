using CSharp.Choices.Attributes;
using Persistence.EfCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Domain.DeleteOrderOp
{
    [AsChoice]
    public static partial class DeleteOrderResult
    {
        public interface IDeleteOrderResult { }

        public class OrderDeleted : IDeleteOrderResult
        {
            public Order Order { get; }

            public OrderDeleted(Order order)
            {
                Order = order;
            }
        }

        public class OrderNotDeleted : IDeleteOrderResult
        {
            public String Reason { get; }

            public OrderNotDeleted(String reason)
            {
                Reason = reason;
            }
        }
    }
}