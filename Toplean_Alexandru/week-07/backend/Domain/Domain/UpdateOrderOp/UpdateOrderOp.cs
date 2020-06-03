using Infrastructure.Free;
using LanguageExt;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using static Domain.Domain.UpdateOrderOp.UpdateOrderResult;

namespace Domain.Domain.UpdateOrderOp
{
    public class UpdateOrderOp : OpInterpreter<UpdateOrderCmd, IUpdateOrderResult, Unit>
    {
        public override Task<IUpdateOrderResult> Work(UpdateOrderCmd Op, Unit state)
        {
            try
            {
                return Task.FromResult<IUpdateOrderResult>(new OrderUpdated(Op.Order));
            }
            catch (Exception exp)
            {
                return Task.FromResult<IUpdateOrderResult>(new OrderNotUpdated(exp.Message));
            }
        }
    }
}