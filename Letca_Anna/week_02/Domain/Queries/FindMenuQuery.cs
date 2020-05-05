using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Persistence.Abstractions;
using Persistence.EfCore;


namespace Domain.Queries
{
    public class FindMenuQuery : Query<Menus>
    {
        public FindMenuQuery(int restaurantId) : base(async (ctx) =>
        {
            return
                await ctx.Set<Menus>()
                    .Where(p => p.RestaurantId == restaurantId)
                    .FirstOrDefaultAsync();
        })
        { }
    }
}
