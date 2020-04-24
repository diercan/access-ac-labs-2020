using System;
using System.Collections.Generic;
using System.Text;
using CSharp.Choices.Attributes;
using Domain.Models;
using System.Threading.Tasks;
using System.ComponentModel.Design.Serialization;

namespace Domain.Domain.EmployeeRoles.GetOrdersOp
{
    [AsChoice]
    public static partial class GetOrdersResult
    {
        public interface IGetOrdersResult { }

        public class GetOrdersResultSuccessful : IGetOrdersResult
        {
            public List<Order> OrdersList { get; }

            public GetOrdersResultSuccessful(List<Order> ordersList)
            {
                OrdersList = ordersList;
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
