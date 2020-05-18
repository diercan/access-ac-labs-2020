using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Domain.Models;
using Infrastructure.Free;
using LanguageExt;
using LanguageExt.ClassInstances.Pred;
using static Domain.Domain.SetOrderStatusOp.SetOrderStatusResult;

namespace Domain.Domain.SetOrderStatusOp
{
    public class SetOrderStatusOp : OpInterpreter<SetOrderStatusCmd, SetOrderStatusResult.ISetOrderStatusResult, Unit>
    {
        public override Task<ISetOrderStatusResult> Work(SetOrderStatusCmd Op, Unit state)
        {
            Op.Order.OrderStatus = Op.OrderStatus;
            Op.Order.PreparationTime = Op.PreparationTime;

            return Task.FromResult<ISetOrderStatusResult>(new SetOrderStatusSuccessful(new OrderAgg(Op.Order)));
        }
    }
}
