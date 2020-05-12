using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Database.Abstractions;
using Database.Context;
using Infrastructure.Free;
using LanguageExt;

namespace Database.Operations
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
