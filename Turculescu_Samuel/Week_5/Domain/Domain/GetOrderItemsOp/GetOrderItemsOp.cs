using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Domain.Models;
using Infrastructure.Free;
using LanguageExt;
using LanguageExt.ClassInstances.Pred;
using Persistence.EfCore;
using static Domain.Domain.GetOrderItemsOp.GetOrderItemsResult;

namespace Domain.Domain.GetOrderItemsOp
{
    public class GetOrderItemsOp : OpInterpreter<GetOrderItemsCmd, GetOrderItemsResult.IGetOrderItemsResult, Unit>
    {
        public override Task<IGetOrderItemsResult> Work(GetOrderItemsCmd Op, Unit state)
        {
            return (Op.OrderItems is null) ?
                Task.FromResult<IGetOrderItemsResult>(new OrderItemsNotFound("OrderItem not found!")) :
                Task.FromResult<IGetOrderItemsResult>(new OrderItemsFound(Op.OrderItems));
        }
    }
}
