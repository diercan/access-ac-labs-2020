using Infrastructure.Free;
using LanguageExt;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using static Domain.Domain.SelectOrderOp.SelectOrderResult;

namespace Domain.Domain.SelectOrderOp
{
    public class SelectOrderOp : OpInterpreter<SelectOrderCmd, ISelectOrderResult, Unit>
    {
        public override Task<ISelectOrderResult> Work(SelectOrderCmd Op, Unit state)
        {
            try
            {
                return Task.FromResult<ISelectOrderResult>(new OrderSelected(new Models.OrderAgg(Op.Order)));
            }
            catch (Exception exp)
            {
                return Task.FromResult<ISelectOrderResult>(new OrderNotSelected(exp.Message));
            }
        }
    }
}