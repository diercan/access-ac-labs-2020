using Infrastructure.Free;
using LanguageExt;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using static Domain.Domain.UpdateOrderOp.UpdateOrderResult;

namespace Domain.Domain.UpdateOrderOp
{
    internal class UpdateOrderOp : OpInterpreter<UpdateOrderOp, IUpdateOrderResult, Unit>
    {
        public override Task<IUpdateOrderResult> Work(UpdateOrderOp Op, Unit state)
        {
            try
            {
                return Task.FromResult<IUpdateOrderResult>(new OrderUpdated(null));
            }
            catch (Exception exp)
            {
                return Task.FromResult<IUpdateOrderResult>(new OrderNotUpdated(exp.Message));
            }
        }
    }
}