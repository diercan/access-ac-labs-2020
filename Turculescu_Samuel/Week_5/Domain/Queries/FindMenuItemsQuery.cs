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
    class FindMenuItemsQuery : Query<List<MenuItem>>
    {
        public FindMenuItemsQuery(Menu menu) : base(async (ctx) =>
        {
            return
                 await ctx.Set<MenuItem>()
                    .Where(m => m.MenuId.Equals(menu.Id))
                    .ToListAsync();
        })
        { }
    }
}
