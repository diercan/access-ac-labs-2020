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
    public class UpdateEntityOp<T> : OpInterpreter<UpdateEntityCmd<T>, IUpdateEntityResult<T>, Unit>
    {
        public override Task<IUpdateEntityResult<T>> Work(UpdateEntityCmd<T> Op, Unit state)
        {
            try
            {
                Op.CommandIsValid();
                return Task.FromResult<IUpdateEntityResult<T>>(new EntityUpdated<T>(Op.Entity));
            }
            catch (Exception exp)
            {
                return Task.FromResult<IUpdateEntityResult<T>>(new EntityNotUpdated<T>(exp.Message));
            }
        }
    }
}