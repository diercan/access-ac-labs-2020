using Persistence.Abstractions;
using Persistence.EfCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Domain.Queries
{
    public class GetAllMenuItemsQuery : Query<ICollection<MenuItem>>
    {
        public GetAllMenuItemsQuery(int id) : base(async (ctx) =>
        {
            return
                ctx.Set<MenuItem>().Where(e => e.MenuId == id).ToHashSet();
        })
        { }
    }
}