using Domain.Domain;
using Domain.Domain.GetRestaurantOp;
using Infrastructure.Free;
using LanguageExt;
using Microsoft.AspNetCore.Mvc;
using Persistence.EfCore;
using System.Threading.Tasks;

namespace OrderAndPay.Web.Controllers
{
    [Route("client")]
    public class ClientController
    {
        public readonly LiveInterpreterAsync _interpreter;
        public ClientController(LiveInterpreterAsync interpreter)
        {
            _interpreter = interpreter;
        }

        [HttpGet("restaurant/{name}")]
        public async Task<IActionResult> GetRestaurant(string name)
        {
            var getRestaurantExpr =from restaurant in RestaurantDomain.GetRestaurant(name)
                                   select restaurant;

            var result = await _interpreter.Interpret(getRestaurantExpr, Unit.Default);

            return result.Match(
                found => (IActionResult)new OkObjectResult(found.RestaurantAgg.Restaurant),
                notFound => new NotFoundResult());
        }
    }
}
