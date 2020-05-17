using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Database.Abstractions;
using Database.Context;
using Infrastructure.Free;
using LanguageExt;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.EntityFrameworkCore;
using Exception = System.Exception;

namespace Database.Operations
{
    public class AddOrUpdateOp : OpInterpreter<AddOrUpdateCmd, AddOrUpdateResult.IAddOrUpdateResult, Unit>
    {
        private readonly OrderAndPayContext _ctx;

        public AddOrUpdateOp(OrderAndPayContext ctx)
        {
            _ctx = ctx;
        }
        public override async Task<AddOrUpdateResult.IAddOrUpdateResult> Work(AddOrUpdateCmd Op, Unit state)
        {
            try
            {
                var entity = _ctx.Entry(Op.Item);
                switch (entity.State)
                {
                    case EntityState.Detached:
                        _ctx.Add(Op.Item);
                        break;
                    case EntityState.Unchanged:
                        _ctx.Update(Op.Item);
                        break;
                    default:
                        return new AddOrUpdateResult.Failed($"Entity is in an incorrect state. Expected Detached or Unchanged. Got {entity.State.ToString()}");
                }
                await _ctx.SaveChangesAsync();
                return new AddOrUpdateResult.Successful(entity.Entity);
            }
            catch (Exception ex)
            {
                return new AddOrUpdateResult.Failed(ex.ToString());
            }
        }
    }
}
