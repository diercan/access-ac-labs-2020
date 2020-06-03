using CSharp.Choices.Attributes;
using Domain.Models;
using Persistence.EfCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Domain.UpdateOrderOp
{
    [AsChoice]
    public static partial class UpdateOrderResult
    {
        public interface IUpdateOrderResult { }

        public class OrderUpdated : IUpdateOrderResult
        {
            public Order Order { get; }

            public OrderUpdated(Order order)
            {
                Order = order;
            }
        }

        public class OrderNotUpdated : IUpdateOrderResult
        {
            public String Reason { get; }

            public OrderNotUpdated(String reason)
            {
                Reason = reason;
            }
        }
    }
}