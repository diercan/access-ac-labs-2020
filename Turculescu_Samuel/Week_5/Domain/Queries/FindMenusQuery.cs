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
    class FindMenusQuery : Query<List<Menu>>
    {
        public FindMenusQuery(Restaurant restaurant) : base(async (ctx) =>
        {
            return
                 await ctx.Set<Menu>()
                    .Where(m => m.RestaurantId.Equals(restaurant.Id))
                    .ToListAsync();
        })
        { }
    }
}
