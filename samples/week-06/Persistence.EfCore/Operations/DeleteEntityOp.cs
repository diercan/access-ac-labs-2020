using Infrastructure.Free;
using LanguageExt;
using Persistence.Abstractions;
using Persistence.EfCore.Context;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using static Persistence.Abstractions.DeleteEntityResult;

namespace Persistence.EfCore.Operations
{
    public class DeleteEntityOp : OpInterpreter<DeleteEntityCmd, IDeteleEntityResult, Unit>
    {
        private readonly OrderAndPayContext _context;

        public DeleteEntityOp(OrderAndPayContext context)
        {
            _context = context;
        }

        public override async Task<IDeteleEntityResult> Work(DeleteEntityCmd Op, Unit state)
        {
            try
            {
                var entity = _context.Entry(Op.Item);
                //if (entity.State == Microsoft.EntityFrameworkCore.EntityState.De)
                // {
                _context.Remove(Op.Item);
                await _context.SaveChangesAsync();
                return new Success();
                //}
                //else
                // {
                //     return new Failed("Incorrect entity state! Expected Detached, got" + entity.State);
                //}
            }
            catch (Exception exp)
            {
                Console.WriteLine(exp.ToString());
                return new Failed(exp.ToString());
            }
        }
    }
}