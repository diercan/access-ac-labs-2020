using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Infrastructure.Free;
using LanguageExt;
using Microsoft.EntityFrameworkCore;
using Persistence.Abstractions;
using Persistence.EfCore.Context;

namespace Persistence.EfCore.Operations
{
    public class DeleteOp : OpInterpreter<DeleteCmd, DeleteResult.IDeleteResult, Unit>
    {
        private readonly OrderAndPayContext _ctx;

        public DeleteOp(OrderAndPayContext ctx)
        {
            _ctx = ctx;
        }

        public override async  Task<DeleteResult.IDeleteResult> Work(DeleteCmd Op, Unit state)
        {
            try
            {
                var entity = _ctx.Entry(Op.Item);
                switch (entity.State)
                {
                    case EntityState.Unchanged:
                        entity.State = EntityState.Deleted;
                        await _ctx.SaveChangesAsync();
                        return new DeleteResult.Successful(entity.Entity);
                    case EntityState.Added:
                        _ctx.Remove(entity);
                        return new DeleteResult.Successful(entity.Entity);
                    default:
                        return new DeleteResult.Failed($"Entity is in an incorrect state. Expected Added or Unchanged. Got {entity.State.ToString()}");
                }
            }
            catch (Exception ex)
            {
                //log exception
                return new DeleteResult.Failed(ex.ToString());
            }
        }
    }
}
