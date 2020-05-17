using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Database.Abstractions
{
    public abstract class Query<TResult>
    {
        public Func<DbContext, Task<TResult>> Executor { get; }

        public Query(Func<DbContext, Task<TResult>> query)
        {
            Executor = query;
        }
    }
}
