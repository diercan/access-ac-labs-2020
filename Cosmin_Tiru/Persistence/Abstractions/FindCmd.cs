using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Persistence.Abstractions
{
    public abstract class QueryCmd<TResult>
    {
        public Func<DbContext, Task<TResult>> Query { get; }

        public QueryCmd(Func<DbContext, Task<TResult>> query)
        {
            Query = query;
        }
    }
}
