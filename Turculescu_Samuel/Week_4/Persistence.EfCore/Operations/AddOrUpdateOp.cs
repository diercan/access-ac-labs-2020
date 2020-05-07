using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Infrastructure.Free;
using LanguageExt;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.EntityFrameworkCore;
using Persistence.Abstractions;
using Persistence.EfCore.Context;
using static Persistence.Abstractions.AddOrUpdateResult;
using Exception = System.Exception;

namespace Persistence.EfCore.Operations
{
    public class AddOrUpdateOp : OpInterpreter<AddOrUpdateCmd, IAddOrUpdateResult, Unit>
    {
        private readonly OrderAndPayContext _ctx;

        public AddOrUpdateOp(OrderAndPayContext ctx)
        {
            _ctx = ctx;
        }
        public override async Task<IAddOrUpdateResult> Work(AddOrUpdateCmd Op, Unit state)
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
                        return new Failed($"Entity is in an incorrect state. Expected Detached or Unchanged. Got {entity.State.ToString()}");
                }
                await _ctx.SaveChangesAsync();
                return new Successful(entity.Entity);
            }
            catch (Exception ex)
            {
                return new Failed(ex.ToString());
            }
        }
    }
}
