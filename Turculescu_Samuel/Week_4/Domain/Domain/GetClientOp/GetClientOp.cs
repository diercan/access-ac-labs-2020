using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Domain.Models;
using Infrastructure.Free;
using LanguageExt;
using LanguageExt.ClassInstances.Pred;
using Persistence.EfCore;
using static Domain.Domain.GetClientOp.GetClientResult;

namespace Domain.Domain.GetClientOp
{
    public class GetClientOp : OpInterpreter<GetClientCmd, GetClientResult.IGetClientResult, Unit>
    {        
        public override Task<IGetClientResult> Work(GetClientCmd Op, Unit state)
        {
            return (Op.Client is null) ?
                Task.FromResult<IGetClientResult>(new ClientNotFound("Client not found!")) :
                Task.FromResult<IGetClientResult>(new ClientFound(new ClientAgg(Op.Client)));
        }
    }
}