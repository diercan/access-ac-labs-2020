using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Models;
using Microsoft.EntityFrameworkCore;
using Persistence.Abstractions;
using Persistence.EfCore;


namespace Domain.Queries
{
    public class FindMenuQuery : Query<Menus>
    {
        public FindMenuQuery(int restaurantId) : base(async (ctx) =>
        {
            return
                await ctx.Set<Menus>()
                    .Where(p => p.RestaurantId == restaurantId)
                    .FirstOrDefaultAsync();
        })
        { }
    }
}
