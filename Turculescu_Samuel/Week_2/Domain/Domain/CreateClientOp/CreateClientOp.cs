using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Domain.Models;
using Infrastructure.Free;
using LanguageExt;
using LanguageExt.ClassInstances.Pred;
using static Domain.Domain.CreateClientOp.CreateClientResult;

namespace Domain.Domain.CreateClientOp
{
    public class CreateClientOp : OpInterpreter<CreateClientCmd, CreateClientResult.ICreateClientResult, Unit>
    {
        public override Task<ICreateClientResult> Work(CreateClientCmd Op, Unit state)
        {
            //validate

            return !Exists(Op.Name) ?
                Task.FromResult<ICreateClientResult>(new ClientNotCreated("client already exists")) :
                Task.FromResult<ICreateClientResult>(new ClientCreated(new Client(Op.Name)));
        }


        public bool Exists(string name)
        {
            return true;
        }
    }
}
