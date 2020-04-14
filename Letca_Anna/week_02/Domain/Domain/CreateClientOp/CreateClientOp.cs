using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Domain.Models;
using Infrastructure.Free;
using LanguageExt;
using static Domain.Domain.CreateClientOp.CreateClientResult;
using LanguageExt.ClassInstances.Pred;

namespace Domain.Domain.CreateClientOp
{
    public class CreateClientOp : OpInterpreter<CreateClientCmd, ICreateClientResult, Unit>
    {
        public override Task<ICreateClientResult> Work(CreateClientCmd Op, Unit state)
        {

            var (valid, validationMessage) = Op.Validate();

            if (!valid)
                return Task.FromResult((ICreateClientResult)new ClientNotCreated(validationMessage));

            return Task.FromResult((ICreateClientResult)new ClientCreated(new Client(Op.Uid)));
        }
    }
}
