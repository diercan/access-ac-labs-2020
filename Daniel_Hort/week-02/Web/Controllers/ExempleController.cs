using System.Threading.Tasks;
using Database.Context;
using Microsoft.AspNetCore.Mvc;
using Web.Controllers.Base;

namespace Web.Controllers
{
    public class ExempleController : BaseController
    {
        public ExempleController(OrderAndPayContext context) : base(context)
        {
        }

        [HttpGet]
        public async Task<IActionResult> GetRestaurants()
        {
            var dbset = _context.RestaurantDbSet;
            var result = await Task.Run(() => dbset);
            return Ok(result);
        }
    }
}