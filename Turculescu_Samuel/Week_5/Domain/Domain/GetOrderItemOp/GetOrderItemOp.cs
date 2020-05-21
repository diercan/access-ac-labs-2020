using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Domain.Models;
using Infrastructure.Free;
using LanguageExt;
using LanguageExt.ClassInstances.Pred;
using Persistence.EfCore;
using static Domain.Domain.GetOrderItemOp.GetOrderItemResult;

namespace Domain.Domain.GetOrderItemOp
{
    public class GetOrderItemOp : OpInterpreter<GetOrderItemCmd, GetOrderItemResult.IGetOrderItemResult, Unit>
    {        
        public override Task<IGetOrderItemResult> Work(GetOrderItemCmd Op, Unit state)
        {
            return (Op.OrderItem is null) ?
                Task.FromResult<IGetOrderItemResult>(new OrderItemNotFound("OrderItem not found!")) :
                Task.FromResult<IGetOrderItemResult>(new OrderItemFound(new OrderItemAgg(Op.OrderItem)));
        }
    }
}