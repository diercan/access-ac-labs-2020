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

        public class GetOrdersResultSuccessful : IGetOrdersResult
        {
            public ICollection<Order> Orders { get; }

            public GetOrdersResultSuccessful(ICollection<Order> orders)
            {
                Orders = orders;
            }
        }

        public class GetOrdersResultNotSuccessful : IGetOrdersResult
        {
            public string Reason;

            public GetOrdersResultNotSuccessful(string reason)
            {
                Reason = reason;
            }
        }
    }
}
