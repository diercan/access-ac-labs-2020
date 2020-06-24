using Microsoft.EntityFrameworkCore;
using Persistence.Abstractions;
using Persistence.EfCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Domain.Queries
{
    internal class GetMenuItemByIdQuery : Query<MenuItem>
    {
        public GetMenuItemByIdQuery(int menuItemId) : base(async (ctx) =>
        {
            return
                await ctx.Set<MenuItem>()
                    .Where(p => p.Id == menuItemId)
                    .FirstOrDefaultAsync();
        })
        { }
    }
}