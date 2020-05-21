using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Domain.GetRestaurantOp;
using Domain.Domain;
using Infrastructure.Free;
using LanguageExt;
using Microsoft.AspNetCore.Mvc;
using Persistence.EfCore;

namespace OrderAndPay.Web.Controllers
{
    [ApiController]
    [Route("client")]
    public class ClientController : ControllerBase
    {
        private readonly LiveInterpreterAsync _interpreter;
          
        public ClientController(LiveInterpreterAsync interpreter)
        {
            _interpreter = interpreter;
        }

        [HttpGet("restaurant/{name}")]
        public async Task<IActionResult> GetRestaurant(string name)
        {
            var getRestaurantExpr =
               from restaurantResult in RestaurantDomain.GetRestaurant(name)
               select restaurantResult;
            var restaurant = await _interpreter.Interpret(getRestaurantExpr, Unit.Default);

            return restaurant.Match(
                found => (IActionResult)Ok(found.Agg.Restaurant),
                notFound => NotFound());
        }

        [HttpGet("restaurant/{name}/menu")]
        public async Task<IActionResult> GetMenus(string name)
        {
            var getRestaurantExpr =
              from restaurantResult in RestaurantDomain.GetRestaurant(name)
              select restaurantResult;
            var restaurant = await _interpreter.Interpret(getRestaurantExpr, Unit.Default);

            return restaurant.Match(
                found => (IActionResult)Ok(found.Agg.Restaurant.Menus),
                notFound => NotFound());
        }
    }
}