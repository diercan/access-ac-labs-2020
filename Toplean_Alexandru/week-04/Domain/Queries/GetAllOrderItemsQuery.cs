using Persistence.Abstractions;
using Persistence.EfCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Domain.Queries
{
    internal class GetAllOrderItemsQuery : Query<ICollection<OrderItems>>
    {
        public GetAllOrderItemsQuery(int id) : base(async (ctx) =>
        {
            return
                ctx.Set<OrderItems>().Where(e => e.OrderId == id).ToHashSet();
        })
        { }
    }
}