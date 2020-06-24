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
    class FindOrderItemsQuery : Query<List<OrderItem>>
    {
        public FindOrderItemsQuery(Order order) : base(async (ctx) =>
        {
            return
                 await ctx.Set<OrderItem>()
                    .Where(o => o.OrderId.Equals(order.Id))
                    .ToListAsync();
        })
        { }
    }
}
