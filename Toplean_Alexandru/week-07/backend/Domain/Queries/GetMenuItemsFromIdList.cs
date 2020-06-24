using Persistence.Abstractions;
using Persistence.EfCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Domain.Queries
{
    internal class GetMenuItemsFromIdList : Query<ICollection<MenuItem>>
    {
        public GetMenuItemsFromIdList(int[] ids) : base(async (ctx) =>
        {
            return
                ctx.Set<MenuItem>().Where(e => ids.Contains(e.Id)).ToHashSet();
        })
        { }
    }
}