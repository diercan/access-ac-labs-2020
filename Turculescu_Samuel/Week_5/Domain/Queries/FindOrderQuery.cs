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
    class FindOrderQuery : Query<Order>
    {
        public FindOrderQuery(int orderId) : base(async (ctx) =>
        {
            return
                 await ctx.Set<Order>()
                    .Where(o => o.Id.Equals(orderId))
                    .FirstOrDefaultAsync();
        })
        { }
    }
}
