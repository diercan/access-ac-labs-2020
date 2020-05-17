using Microsoft.EntityFrameworkCore;
using Persistence.Abstractions;
using Persistence.EfCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Domain.Queries
{
    public class GetMenuQuery : Query<Menu>
    {
        public GetMenuQuery(string menuName, int restaurantId) : base(async (ctx) =>
        {
            return
                await ctx.Set<Menu>()
                    .Where(p => p.Name.Equals(menuName) && p.RestaurantId == restaurantId)
                    .FirstOrDefaultAsync();
        })
        { }
    }
}