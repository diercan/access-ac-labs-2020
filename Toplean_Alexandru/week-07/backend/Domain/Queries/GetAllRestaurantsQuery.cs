using Persistence.Abstractions;
using Persistence.EfCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Domain.Queries
{
    internal class GetAllRestaurantsQuery : Query<ICollection<Restaurant>>
    {
        public GetAllRestaurantsQuery() : base(async (ctx) =>
        {
            return
                ctx.Set<Restaurant>().ToHashSet();
        })
        { }
    }
}