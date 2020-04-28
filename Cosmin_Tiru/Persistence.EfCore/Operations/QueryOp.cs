using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Infrastructure.Free;
using LanguageExt;
using Persistence.Abstractions;
using Persistence.EfCore.Context;

namespace Persistence.EfCore.Operations
{
    public class QueryOp<TQuery, TResult> : OpInterpreter<TQuery, TResult, Unit>
        where TQuery : QueryCmd<TResult>
    {
        private readonly OrderAndPayContext _ctx;

        public QueryOp(OrderAndPayContext ctx)
        {
            _ctx = ctx;
        }

        public override async Task<TResult> Work(TQuery Op, Unit state)
        {
            var result = await Op.Query(_ctx);
            return result;
        }
    }
}
