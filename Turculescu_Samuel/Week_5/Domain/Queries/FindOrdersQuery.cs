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
    class FindOrdersQuery : Query<List<Order>>
    {
        public FindOrdersQuery(Restaurant restaurant) : base(async (ctx) =>
        {
            return
                 await ctx.Set<Order>()
                    .Where(o => o.RestaurantId.Equals(restaurant.Id))
                    .ToListAsync();
        })
        { }
    }   
}
