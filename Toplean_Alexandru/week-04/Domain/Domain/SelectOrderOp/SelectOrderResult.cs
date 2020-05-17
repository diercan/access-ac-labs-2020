using CSharp.Choices.Attributes;
using Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Domain.SelectOrderOp
{
    [AsChoice]
    public static partial class SelectOrderResult
    {
        public interface ISelectOrderResult { }

        public class OrderSelected : ISelectOrderResult
        {
            public OrderAgg OrderAgg { get; }

            public OrderSelected(OrderAgg order)
            {
                OrderAgg = order;
            }
        }

        public class OrderNotSelected : ISelectOrderResult
        {
            public String Reason { get; }

            public OrderNotSelected(String reason)

            {
                Reason = reason;
            }
        }
    }
}