using Domain.Domain;
using Domain.Domain.GetRestaurantOp;
using Infrastructure.Free;
using LanguageExt;
using Microsoft.AspNetCore.Mvc;
using Persistence.Abstractions;
using Persistence.EfCore;
using System.Threading.Tasks;
using static Domain.Domain.CreateRestauratOp.CreateRestaurantResult;
using static Domain.Domain.GetRestaurantOp.GetRestaurantResult;
using static Domain.Domain.GetSpecificMenu.GetSpecificMenuResult;

namespace OrderAndPay.Web.Controllers
{
    [Route("Employee")]
    public class EmployeeController
    {
        public readonly LiveInterpreterAsync _interpreter;

        public EmployeeController(LiveInterpreterAsync interpreter)
        {
            this._interpreter = interpreter;
        }
        [HttpPost("{restaurantname}/createmenu")]
        public async Task<IActionResult> CreateMenu(string restaurantname, [FromBody] Menus menu)
        {
            var menuExpr = from restaurant in RestaurantDomain.GetRestaurant(restaurantname)
                                 let restaurantFoundId = (restaurant as RestaurantFound)?.RestaurantAgg.Restaurant.Id
                                 from persistedMenu in RestaurantDomain.CreateMenuAndPersist(menu, restaurantFoundId)
                                 select persistedMenu;

            var result = await _interpreter.Interpret(menuExpr, Unit.Default);

            return result.Match(
                succesful => (IActionResult)new OkObjectResult(menu),
                failed => new NotFoundObjectResult(failed.Reason));
        }

        [HttpPost("{restaurantname}/{menuname}/createitem")]
        public async Task<IActionResult> CreateMenuItem(string restaurantname, string menuname,[FromBody] MenuItems menuItem)
        {
            var menuExpr = from restaurant in RestaurantDomain.GetRestaurant(restaurantname)
                           let restaurantFound = (restaurant as RestaurantFound)?.RestaurantAgg.Restaurant
                           from menu in RestaurantDomain.GetSpecificMenu(restaurantFound, menuname)
                           let foundMenuId = (menu as SpecificMenuFound)?.Menu.Id
                           from menuitemPersisted in RestaurantDomain.CreateMenuItemAndPersist(menuItem, foundMenuId)
                           select menuitemPersisted;


            var result = await _interpreter.Interpret(menuExpr, Unit.Default);

            return result.Match(
                succesful => (IActionResult)new OkObjectResult(menuItem),
                failed => new NotFoundObjectResult(failed.Reason));
        }
    }
}
