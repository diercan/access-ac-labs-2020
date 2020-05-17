using Microsoft.EntityFrameworkCore;
using Persistence.Abstractions;
using Persistence.EfCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Domain.Queries
{
    internal class GetMenuItemQuery : Query<MenuItem>
    {
        public GetMenuItemQuery(string menuItemName, int menuId) : base(async (ctx) =>
        {
            return
                await ctx.Set<MenuItem>()
                    .Where(p => p.Name.Equals(menuItemName) && p.MenuId == menuId)
                    .FirstOrDefaultAsync();
        })
        { }
    }
}