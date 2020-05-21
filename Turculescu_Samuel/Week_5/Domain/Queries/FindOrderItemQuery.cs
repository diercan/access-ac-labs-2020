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
    class FindOrderItemQuery : Query<OrderItem>
    {
        public FindOrderItemQuery(int orderItemId) : base(async (ctx) =>
        {
            return
                 await ctx.Set<OrderItem>()
                    .Where(o => o.Id.Equals(orderItemId))
                    .FirstOrDefaultAsync();
        })
        { }
    }
}
