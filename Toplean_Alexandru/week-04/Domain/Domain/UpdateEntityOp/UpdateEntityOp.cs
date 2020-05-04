using Domain.Entities;
using Infrastructure.Free;
using LanguageExt;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using static Domain.Domain.UpdateEntityOp.UpdateEntityResult;

namespace Domain.Domain.UpdateEntityOp
{
    public class UpdateEntityOp : OpInterpreter<UpdateEntityCmd<IEntity>, IUpdateEntityResult<IEntity>, Unit>
    {
        public override Task<IUpdateEntityResult<IEntity>> Work(UpdateEntityCmd<IEntity> Op, Unit state)
        {
            try
            {
                Op.CommandIsValid();
                return Task.FromResult<IUpdateEntityResult<IEntity>>(new EntityUpdated<IEntity>(Op.Entity));
            }
            catch (Exception exp)
            {
                return Task.FromResult<IUpdateEntityResult<IEntity>>(new EntityNotUpdated<IEntity>(exp.Message));
            }
        }
    }
}