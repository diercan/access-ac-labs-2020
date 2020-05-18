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
    class FindMenuItemQuery : Query<MenuItem>
    {
        public FindMenuItemQuery(int menuItemId) : base(async (ctx) =>
        {
            return
                 await ctx.Set<MenuItem>()
                    .Where(m => m.Id.Equals(menuItemId))
                    .FirstOrDefaultAsync();
        })
        { }
    }
}
