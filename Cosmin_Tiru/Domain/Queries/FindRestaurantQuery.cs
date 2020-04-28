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
    public class FindRestaurantQuery : Query<Restaurant>
    {
        public FindRestaurantQuery(string restaurantName) : base(async (ctx) =>
        {
            return 
                await ctx.Set<Restaurant>()
                    .Where(p => p.Name.Equals(restaurantName))
                    .FirstOrDefaultAsync();
        }) {}
    }
}
