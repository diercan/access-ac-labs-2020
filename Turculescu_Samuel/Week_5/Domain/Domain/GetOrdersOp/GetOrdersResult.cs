using System;
using System.Collections.Generic;
using System.Text;
using CSharp.Choices.Attributes;
using Domain.Models;
using System.Threading.Tasks;
using System.ComponentModel.Design.Serialization;
using Persistence.EfCore;

namespace Domain.Domain.GetOrdersOp
{
    [AsChoice]
    public static partial class GetOrdersResult
    {
        public interface IGetOrdersResult { }

        public class GetOrdersSuccessful : IGetOrdersResult
        {
            public List<Order> Orders { get; }

            public GetOrdersSuccessful(List<Order> orders)
            {
                Orders = orders;
            }
        }

        public class GetOrdersNotSuccessful : IGetOrdersResult
        {
            public string Reason;

            public GetOrdersNotSuccessful(string reason)
            {
                Console.WriteLine(reason);
                Reason = reason;
            }
        }
    }
}
