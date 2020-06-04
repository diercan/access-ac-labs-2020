using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Domain;
using Infrastructure.Free;
using LanguageExt;
using Microsoft.AspNetCore.Mvc;
using Persistence.EfCore;
using System.Net.Http;
using System.Net;
using Domain.Domain.GetMenusOp;
using Newtonsoft.Json;
using Domain.Domain.GetRestaurantOp;
using Persistence.EfCore.Context;
using Microsoft.EntityFrameworkCore;

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

        [HttpGet("{name}/menus")]
        public async Task<IActionResult> GetMenus(string name)
        {
            var getRestaurantExpr =
              from restaurantResult in RestaurantDomain.GetRestaurant(name)
              select restaurantResult;
            var restaurant = await _interpreter.Interpret(getRestaurantExpr, Unit.Default);


            return await restaurant.MatchAsync<IActionResult>(
                 async (selected) =>
                 {
                     var getMenusExpr =
                         from menusRestaurant in RestaurantDomainEx.GetMenus(selected.Agg.Restaurant)
                         select menusRestaurant;

                     var menus = await _interpreter.Interpret(getMenusExpr, Unit.Default);

                     return (IActionResult)Ok(JsonConvert.SerializeObject(menus));
                 },
                  async (notSelected) => NotFound()

                 );
        }
    }
}