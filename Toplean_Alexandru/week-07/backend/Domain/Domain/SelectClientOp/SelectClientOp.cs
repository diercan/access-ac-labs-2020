using Infrastructure.Free;
using LanguageExt;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using static Domain.Domain.SelectClientOp.SelectClientResult;

namespace Domain.Domain.SelectClientOp
{
    public class SelectClientOp : OpInterpreter<SelectClientCmd, ISelectClientResult, Unit>
    {
        public override Task<ISelectClientResult> Work(SelectClientCmd Op, Unit state)
        {
            try
            {
                Op.CheckIfValid();
                return Task.FromResult<ISelectClientResult>(new ClientSelected(Op.Client));
            }
            catch (Exception exp)
            {
                return Task.FromResult<ISelectClientResult>(new ClientNotSelected(exp.Message));
            }
        }
    }
}