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
    public class FindMenuItemsQuery : Query<List<MenuItems>>
    {
        public FindMenuItemsQuery(int menuId) : base(async (ctx) =>
        {
            return
                await ctx.Set<MenuItems>()
                    .Where(p => p.MenuId == menuId)
                    .ToListAsync();
        })
        { }
    }
}
