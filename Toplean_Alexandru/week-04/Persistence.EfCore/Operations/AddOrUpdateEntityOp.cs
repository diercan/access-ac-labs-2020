using Infrastructure.Free;
using LanguageExt;
using Microsoft.EntityFrameworkCore;
using Persistence.Abstractions;
using Persistence.EfCore.Context;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using static Persistence.Abstractions.AddOrUpdateEntityResult;

namespace Persistence.EfCore.Operations
{
    public class AddOrUpdateEntityOp : OpInterpreter<AddOrUpdateEntityCmd, IAddOrUpdateEntityResult, Unit>
    {
        private readonly OrderAndPayContext _context;

        public AddOrUpdateEntityOp(OrderAndPayContext context)
        {
            _context = context;
        }

        public override async Task<IAddOrUpdateEntityResult> Work(AddOrUpdateEntityCmd Op, Unit state)
        {
            try
            {
                var entity = _context.Entry(Op.Item);
                switch (entity.State)
                {
                    case EntityState.Detached:
                        _context.Add(Op.Item);
                        break;

                    case EntityState.Unchanged:
                        _context.Update(Op.Item);
                        break;

                    default:
                        return new Failed($"Entity is in an incorrect state. Expected Detached or Unchanged. Got {entity.State.ToString()}");
                }
                await _context.SaveChangesAsync();
                return new Success(entity.Entity);
            }
            catch (Exception ex)
            {
                return new Failed(ex.ToString());
            }
        }
    }
}