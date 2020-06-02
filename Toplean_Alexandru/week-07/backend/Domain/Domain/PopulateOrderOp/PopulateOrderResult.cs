using CSharp.Choices.Attributes;
using Domain.Models;
using Persistence.EfCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Domain.PopulateOrderOp
{
    [AsChoice]
    public static partial class PopulateOrderResult
    {
        public interface IPopulateOrderResult { }

        public class OrderPopulated : IPopulateOrderResult
        {
            public ICollection<Order> Order { get; }

            public OrderPopulated(ICollection<Order> order)
            {
                Order = order;
            }
        }

        public class OrderNotPopulated : IPopulateOrderResult
        {
            public String Reason { get; }

            public OrderNotPopulated(String reason)
            {
                Reason = reason;
            }
        }
    }
}