﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Persistence.Abstractions;
using Persistence.EfCore;

namespace Domain.Queries
{
    class FindRestaurantsQuery : Query<List<Restaurant>>
    {
        public FindRestaurantsQuery() : base(async (ctx) =>
        {
            return
                await ctx.Set<Restaurant>()
                    .ToListAsync();
        })
        { }
    }
}
