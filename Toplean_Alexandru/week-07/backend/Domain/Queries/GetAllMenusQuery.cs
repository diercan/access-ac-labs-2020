using Microsoft.EntityFrameworkCore;
using Persistence.Abstractions;
using Persistence.EfCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Domain.Queries
{
    public class GetAllMenusQuery : Query<ICollection<Menu>>
    {
        public GetAllMenusQuery(int id) : base(async (ctx) =>
        {
            return
                ctx.Set<Menu>().Where(e => e.RestaurantId == id).ToHashSet();
        })
        { }
    }
}