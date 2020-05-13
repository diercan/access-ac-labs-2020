using Microsoft.EntityFrameworkCore;
using Persistence.Abstractions;
using Persistence.EfCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Domain.Queries
{
    internal class GetClientQuery : Query<Client>
    {
        public GetClientQuery(string name) : base(async (ctx) =>
        {
            return
                await ctx.Set<Client>()
                    .Where(p => p.Username.Equals(name))
                    .FirstOrDefaultAsync();
        })
        { }
    }
}