using Domain.Models;
using Infrastructure.Free;
using LanguageExt;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using static Domain.Domain.UpdateClientOp.UpdateClientResult;

namespace Domain.Domain.UpdateClientOp
{
    public class UpdateClientOp : OpInterpreter<UpdateClientCmd, IUpdateClientResult, Unit>
    {
        public async override Task<IUpdateClientResult> Work(UpdateClientCmd Op, Unit state)
        {
            return new ClientUpdated(new ClientAgg(Op.Client));
        }
    }
}