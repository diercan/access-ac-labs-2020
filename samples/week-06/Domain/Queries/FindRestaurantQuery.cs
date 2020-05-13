using Persistence.Abstractions;
using Persistence.EfCore;
using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Domain.Models;

namespace Domain.Queries
{
    public class FindRestaurantQuery : Query<Restaurant>
    {
        public FindRestaurantQuery(string restaurantName) : base(async (ctx) =>
        {
            return
                await ctx.Set<Restaurant>()
                    .Where(p => p.Name.Equals(restaurantName))
                    .FirstOrDefaultAsync();
        })
        { }
    }
}