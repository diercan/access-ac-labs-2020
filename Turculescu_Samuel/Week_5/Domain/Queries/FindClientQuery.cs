using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Persistence.Abstractions;
using Persistence.EfCore;

namespace Domain.Queries
{
    public class FindClientQuery : Query<Client>
    {
        public FindClientQuery(string clientId) : base(async (ctx) =>
        {
            return
                await ctx.Set<Client>()
                    .Where(c => c.ClientId.Equals(clientId))
                    .FirstOrDefaultAsync();
        })
        { }
    }
}