using System;
using System.Collections.Generic;
using System.Text;
using CSharp.Choices.Attributes;
using Domain.Models;
using System.Threading.Tasks;

namespace Domain.Domain.ClientRoles.GetOrderStatusOp
{
    [AsChoice]
    public static partial class GetOrderStatusResult
    {        
        public interface IGetOrderStatusResult { }

        public class OrderStatus : IGetOrderStatusResult
        {
            public string StatusMessage { get; }

            public OrderStatus(string statusMessage)
            {
                StatusMessage = statusMessage;
            }
        }
    }
}
