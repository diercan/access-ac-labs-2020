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
    public class GetAllRestaurantsQuery : Query<List<Restaurant>>
    {
        public GetAllRestaurantsQuery() : base(async (ctx) =>
        {
            return
                await ctx.Set<Restaurant>()
                    .Include("Menus.MenuItems")
                    .ToListAsync();
        })
        { }
    }
}
