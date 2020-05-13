using Microsoft.EntityFrameworkCore;
using Persistence.Abstractions;
using Persistence.EfCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Domain.Queries
{
    public class GetOrderQuery : Query<Order>
    {
        public GetOrderQuery(int orderId) : base(async (ctx) =>
        {
            return
                await ctx.Set<Order>()
                    .Where(p => p.Id == orderId)
                    .FirstOrDefaultAsync();
        })
        { }
    }
}