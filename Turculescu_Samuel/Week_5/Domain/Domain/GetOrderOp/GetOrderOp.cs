using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Domain.Models;
using Infrastructure.Free;
using LanguageExt;
using LanguageExt.ClassInstances.Pred;
using Persistence.EfCore;
using static Domain.Domain.GetOrderOp.GetOrderResult;

namespace Domain.Domain.GetOrderOp
{
    public class GetOrderOp : OpInterpreter<GetOrderCmd, GetOrderResult.IGetOrderResult, Unit>
    {        
        public override Task<IGetOrderResult> Work(GetOrderCmd Op, Unit state)
        {
            return (Op.Order is null) ?
                Task.FromResult<IGetOrderResult>(new OrderNotFound("Order not found!")) :
                Task.FromResult<IGetOrderResult>(new OrderFound(new OrderAgg(Op.Order)));
        }
    }
}