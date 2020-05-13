using Infrastructure.Free;
using LanguageExt;
using Persistence.Abstractions;
using Persistence.EfCore.Context;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using static Persistence.Abstractions.AddEntityResult;

namespace Persistence.EfCore.Operations
{
    public class AddEntityOp : OpInterpreter<AddEntityCmd, IAddEntityResult, Unit>
    {
        private readonly OrderAndPayContext _context;

        public AddEntityOp(OrderAndPayContext context)
        {
            _context = context;
        }

        public override async Task<IAddEntityResult> Work(AddEntityCmd Op, Unit state)
        {
            try
            {
                var entity = _context.Entry(Op.Item);
                if (entity.State == Microsoft.EntityFrameworkCore.EntityState.Detached)
                {
                    _context.Add(Op.Item);
                    await _context.SaveChangesAsync();
                    return new Success(entity.Entity);
                }
                else
                {
                    return new Failed("Incorrect entity state! Expected Detached, got" + entity.State);
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