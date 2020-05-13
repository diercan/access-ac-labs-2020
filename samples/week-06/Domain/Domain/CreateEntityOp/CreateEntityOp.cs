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
    internal class CreateEntityOp : OpInterpreter<CreateEntityCmd<IEntity>, ICreateEntityResult<IEntity>, Unit>
    {
        public override Task<ICreateEntityResult<IEntity>> Work(CreateEntityCmd<IEntity> Op, Unit state)
        {
            try
            {
                Op.CommandIsValid();
                return Task.FromResult<ICreateEntityResult<IEntity>>(new EntityCreated<IEntity>(Op.Entity));
            }
            catch (Exception exp)
            {
                return Task.FromResult<ICreateEntityResult<IEntity>>(new EntityNotCreated<IEntity>(exp.Message));
            }
        }
    }
}