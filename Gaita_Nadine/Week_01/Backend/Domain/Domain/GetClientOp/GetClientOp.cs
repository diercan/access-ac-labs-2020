using Domain.Models;
using Infrastructure.Free;
using LanguageExt;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using static Domain.Domain.GetClientOp.GetClientResult;

namespace Domain.Domain.GetClientOp
{
    public class GetClientOp : OpInterpreter<GetClientCmd, IGetClientResult, Unit>
    {
        public override System.Threading.Tasks.Task<IGetClientResult> Work(GetClientCmd Op, Unit state)
        {
            return Task.FromResult<IGetClientResult>(new ClientFound(new Client(Op.Uid)));
        }
    }
}
