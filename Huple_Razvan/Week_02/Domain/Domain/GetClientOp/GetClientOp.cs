using Domain.Models;
using GetClientResult;
using Infrastructure.Free;
using LanguageExt;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using static Domain.Domain.GetClientOp.GetClientResult;
using IGetClientResult = Domain.Domain.GetClientOp.GetClientResult.IGetClientResult;

namespace Domain.Domain.GetClientOp
{
    public class GetClientOp : OpInterpreter<GetClientCmd, GetClientResult.IGetClientResult, Unit>
    {
        public override Task<IGetClientResult> Work(GetClientCmd Op, Unit state)
        {
            //validate
            foreach(Client c in Op.Clients)
                if(c.Name.Equals(Op.Name))
                    return Task.FromResult<IGetClientResult>((IGetClientResult)new ClientFound(c));
            return Task.FromResult<IGetClientResult>((IGetClientResult)new ClientNotFound("not found"));
        }
    }
}
