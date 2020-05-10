using Domain.Entities;
using Infrastructure.Free;
using LanguageExt;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using static Domain.Domain.CreateEntityOp.CreateEntityResult;

namespace Domain.Domain.CreateEntityOp
{
    public class CreateEntityOp : OpInterpreter<CreateEntityCmd, ICreateEntityResult, Unit>
    {
        public override Task<ICreateEntityResult> Work(CreateEntityCmd Op, Unit state)
        {
            try
            {
                Op.CommandIsValid();
                return Task.FromResult<ICreateEntityResult>(new EntityCreated(Op.Entity));
            }
            catch (Exception exp)
            {
                return Task.FromResult<ICreateEntityResult>(new EntityNotCreated(exp.Message));
            }
        }
    }
}