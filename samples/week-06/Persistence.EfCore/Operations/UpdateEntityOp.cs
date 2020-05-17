using Infrastructure.Free;
using LanguageExt;
using Persistence.Abstractions;
using Persistence.EfCore.Context;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using static Persistence.Abstractions.UpdateEntityResult;

namespace Persistence.EfCore.Operations
{
    internal class UpdateEntityOp : OpInterpreter<UpdateEntityCmd, IUpdateEntityResult, Unit>
    {
        private readonly OrderAndPayContext _context;

        public UpdateEntityOp(OrderAndPayContext context)
        {
            _context = context;
        }

        public override async Task<IUpdateEntityResult> Work(UpdateEntityCmd Op, Unit state)
        {
            try
            {
                var entity = _context.Entry(Op.Item);
                if (entity.State == Microsoft.EntityFrameworkCore.EntityState.Unchanged)
                {
                    _context.Update(Op.Item);
                    await _context.SaveChangesAsync();
                    return new Success(entity.Entity);
                }
                else
                {
                    return new Failed("Incorrect entity state! Expected Unchanged, got" + entity.State);
                }
            }
            catch (Exception exp)
            {
                Console.WriteLine(exp.ToString());
                return new Failed(exp.ToString());
            }
        }
    }
}