using Persistence.Abstractions;
using Persistence.EfCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Domain.Queries
{
    internal class GetAllOrdersQuery : Query<ICollection<Order>>
    {
        public GetAllOrdersQuery(int restaurantId) : base(async (ctx) =>
        {
            return
                ctx.Set<Order>().Where(e => e.RestaurantId == restaurantId).ToHashSet();
        })
        { }
    }
}