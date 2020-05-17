using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Persistence.Abstractions;
using Persistence.EfCore;

namespace Domain.Queries
{
    public class FindEmployeeQuery : Query<Employee>
    {
        public FindEmployeeQuery(int restaurantId, int employeeId) : base(async (ctx) =>
        {
            return
                await ctx.Set<Employee>()
                    .Where(c => c.RestaurantId.Equals(restaurantId) && c.Id.Equals(employeeId))
                    .FirstOrDefaultAsync();
        })
        { }
    }
}
