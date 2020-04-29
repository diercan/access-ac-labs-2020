using Infrastructure.Free;
using LanguageExt;
using Persistence.Abstractions;
using Persistence.EfCore.Context;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.EfCore.Operations
{
    public class QueryOp<TQuery, TResult> : OpInterpreter<TQuery, TResult, Unit>
        where TQuery : Query<TResult>
    {
        private readonly OrderAndPayContext _ctx;

        public QueryOp(OrderAndPayContext ctx)
        {
            _ctx = ctx;
        }

        public override async Task<TResult> Work(TQuery Op, Unit state)
        {
            var result = await Op.Executor(_ctx);
            return result;
        }
    }
}