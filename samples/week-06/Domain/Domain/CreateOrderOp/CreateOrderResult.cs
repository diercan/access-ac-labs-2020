using CSharp.Choices.Attributes;
using Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

using System.Threading.Tasks;
using Persistence.EfCore;

namespace Domain.Domain.CreateOrderOp
{
    [AsChoice]
    public static partial class CreateOrderResult
    {
        public interface ICreateOrderResult { }

        public class OrderCreated : ICreateOrderResult
        {
            public OrderAgg OrderAgg { get; }

            public OrderCreated(OrderAgg order)
            {
                OrderAgg = order;
            }
        }

        public class OrderNotCreated : ICreateOrderResult
        {
            public String Reason;

            public OrderNotCreated(String error)
            {
                Reason = error;
            }
        }


        public class InvalidRequest : ICreateOrderResult
        {
            public CreateOrderCmd Cmd { get; }

            public InvalidRequest(CreateOrderCmd cmd)
            {
                Cmd = cmd;
            }
        }
    }
}