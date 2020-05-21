using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Domain.GetRestaurantOp;
using Domain.Domain;
using Infrastructure.Free;
using LanguageExt;
using Microsoft.AspNetCore.Mvc;

namespace OrderAndPay.Web.Controllers
{
    [ApiController]
    [Route("restaurant")]
    public class RestaurantController : ControllerBase
    {
        private readonly LiveInterpreterAsync _interpreter;

        public RestaurantController(LiveInterpreterAsync interpreter)
        {
            _interpreter = interpreter;
        }

        [HttpGet("{name}/employees")]
        public async Task<IActionResult> GetRestaurant(string name)
        {
            var getRestaurantExpr =
               from restaurantResult in RestaurantDomain.GetRestaurant(name)
               select restaurantResult;
            var restaurant = await _interpreter.Interpret(getRestaurantExpr, Unit.Default);

            return restaurant.Match(
                found => (IActionResult)Ok(found.Agg.Restaurant.Employees),
                notFound => NotFound());
        }
    }
}