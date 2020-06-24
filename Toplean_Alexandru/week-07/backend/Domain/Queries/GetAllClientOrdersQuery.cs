using Persistence.Abstractions;
using Persistence.EfCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Domain.Queries
{
    internal class GetAllClientOrdersQuery : Query<ICollection<Order>>
    {
        public GetAllClientOrdersQuery(int clientId) : base(async (ctx) =>
        {
            return
                ctx.Set<Order>().Where(e => e.RestaurantId == clientId).ToHashSet();
        })
        { }
    }
}