using LanguageExt;
using Microsoft.EntityFrameworkCore;
using Persistence.Abstractions;
using Persistence.EfCore;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;

namespace Domain.Queries
{
    class FindClientOrdersQuery : Query<List<Order>>
    {
        public FindClientOrdersQuery(int clientId) : base(async (ctx) =>
        {
            return
                 await ctx.Set<Order>()
                    .Where(o => o.ClientId.Equals(clientId))
                    .ToListAsync();
        })
        { }
    }
}
