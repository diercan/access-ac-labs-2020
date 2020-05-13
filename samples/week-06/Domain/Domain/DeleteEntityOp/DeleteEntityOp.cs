using Infrastructure.Free;
using LanguageExt;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using static Domain.Domain.DeleteEntityOp.DeleteEntityResult;

namespace Domain.Domain.DeleteEntityOp
{
    internal class DeleteEntityOp<T> : OpInterpreter<DeleteEntityCmd<T>, IDeleteEntityResult<T>, Unit>
    {
        public override Task<IDeleteEntityResult<T>> Work(DeleteEntityCmd<T> Op, Unit state)
        {
            try
            {
                Op.CommandIsValid();
                return Task.FromResult<IDeleteEntityResult<T>>(new EntityDeleted<T>(Op.Entity));
            }
            catch (Exception exp)
            {
                return Task.FromResult<IDeleteEntityResult<T>>(new EntityNotDeleted<T>(exp.Message));
            }
        }
    }
}