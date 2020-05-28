using Infrastructure.Free;
using LanguageExt;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using static Domain.Domain.DeleteOrderOp.DeleteOrderResult;

namespace Domain.Domain.DeleteOrderOp
{
    public class DeleteOrderOp : OpInterpreter<DeleteOrderCmd, IDeleteOrderResult, Unit>
    {
        public override Task<IDeleteOrderResult> Work(DeleteOrderCmd Op, Unit state)
        {
            try
            {
                return Task.FromResult<IDeleteOrderResult>(new OrderDeleted(Op.Order));
            }
            catch (Exception exp)
            {
                return Task.FromResult<IDeleteOrderResult>(new OrderNotDeleted(exp.Message));
            }
        }
    }
}