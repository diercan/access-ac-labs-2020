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
    class FindMenuQuery : Query<Menu>
    {
        public FindMenuQuery(int menuId) : base(async (ctx) =>
        {
            return
                 await ctx.Set<Menu>()
                    .Where(m => m.Id.Equals(menuId))
                    .FirstOrDefaultAsync();
        })
        { }
    }
}
