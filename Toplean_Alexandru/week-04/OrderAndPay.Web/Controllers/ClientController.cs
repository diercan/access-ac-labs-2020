using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Domain;
using Domain.Domain.CreateClientOp;
using Domain.Domain.SelectMenuItemOp;
using Infrastructure.Free;
using LanguageExt;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Persistence.EfCore;
using Newtonsoft.Json;
using static Domain.Domain.CreateClientOp.CreateClientResult;
using static Domain.Domain.GetPaymentStatusOp.GetPaymentStatusResult;
using static Domain.Domain.SelectClientOp.SelectClientResult;
using static Domain.Domain.SelectMenuOp.SelectMenuResult;
using static Domain.Domain.SelectRestaurantOp.SelectRestaurantResult;
using static Domain.Domain.PopulateRestaurantOp.PopulateRestaurantResult;
using Persistence;

namespace OrderAndPay.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientController : ControllerBase
    {
        private readonly LiveInterpreterAsync interpreter;

        public ClientController(LiveInterpreterAsync interpreter)
        {
            this.interpreter = interpreter;
        }

        [HttpGet("restaurant/{name}")]
        public async Task<IActionResult> SelectRestaurant(String name)
        {
            var expr = from selectRestaurant in RestaurantDomain.GetRestaurant(name)
                       let restaurant = (selectRestaurant as RestaurantSelected)?.RestaurantAgg
                       from populatedRestaurant in RestaurantDomain.PopulateRestaurant(restaurant, RestaurantDomain.GetAllMenus, RestaurantDomain.GetAllMenuItems, interpreter)
                       let newRestaurant = (populatedRestaurant as RestaurantPopulated)?.RestaurantAgg
                       select populatedRestaurant;

            var exprResult = await interpreter.Interpret(expr, Unit.Default);
            return await exprResult.MatchAsync<IActionResult>(
                async (selected) =>
                {
                    return (IActionResult)Ok(JsonConvert.SerializeObject(selected.RestaurantAgg.Restaurant));
                },
                 async (notSelected) => NotFound()

                );
        }

        [HttpGet("restaurant/{restaurantName}/{menuName}")]
        public async Task<IActionResult> GetMenu(string restaurantName, String menuName)
        {
            //Selecting the restaurant
            var expr = from selectRestaurant in RestaurantDomain.GetRestaurant(restaurantName)
                       let restaurant = (selectRestaurant as RestaurantSelected)?.RestaurantAgg
                       from selectMenu in RestaurantDomain.GetMenu(menuName, restaurant.Restaurant.Id)
                       let menu = (selectMenu as MenuSelected)?.MenuAgg
                       select selectMenu;

            var exprResult = await interpreter.Interpret(expr, Unit.Default);
            return await exprResult.MatchAsync<IActionResult>(
                        async (selected) => // Menu was successfully selected
                        {
                            return (IActionResult)Ok(selected.MenuAgg.Menu);
                        },
                        async (notSelected) => // Menu not selected
                        {
                            return NotFound();
                        }

                        );
        }

        [HttpGet("restaurant/{restaurantName}/AllMenus")]
        public async Task<IActionResult> GetAllMenus(String restaurantName)
        {
            var expr = from selectRestaurant in RestaurantDomain.GetRestaurant(restaurantName)
                       let restaurant = (selectRestaurant as RestaurantSelected)?.RestaurantAgg
                       from populatedRestaurant in RestaurantDomain.PopulateRestaurant(restaurant, RestaurantDomain.GetAllMenus, RestaurantDomain.GetAllMenuItems, interpreter)
                       let newRestaurant = (populatedRestaurant as RestaurantPopulated)?.RestaurantAgg
                       select populatedRestaurant;

            var exprResult = await interpreter.Interpret(expr, Unit.Default);

            return await exprResult.MatchAsync<IActionResult>(
                async (selected) =>
                {
                    var getAllMenusExpr = from getAllMenus in RestaurantDomain.GetAllMenus(selected.RestaurantAgg.Restaurant.Id)
                                          select getAllMenus;

                    var getAllMenusResult = await interpreter.Interpret(getAllMenusExpr, Unit.Default);

                    return (IActionResult)Ok(JsonConvert.SerializeObject(getAllMenusResult));
                },
                 async (notSelected) => NotFound()

                );
        }

        [HttpGet("restaurant/{restaurantName}/{menuName}/{menuItemName}")]
        public async Task<IActionResult> GetMenuItem(String restaurantName, String menuName, String menuItemName)
        {
            var getMenuItemExpr = from restaurantResult in RestaurantDomain.GetRestaurant(restaurantName)
                                  let restaurant = (restaurantResult as RestaurantSelected)?.RestaurantAgg.Restaurant
                                  from menuResult in RestaurantDomain.GetMenu(menuName, restaurant.Id)
                                  let menu = (menuResult as MenuSelected)?.MenuAgg.Menu
                                  from menuItemResult in RestaurantDomain.GetMenuItem(menuItemName, menu.Id)

                                  select menuItemResult;

            var getMenuItemResult = await interpreter.Interpret(getMenuItemExpr, Unit.Default);
            return await getMenuItemResult.MatchAsync<IActionResult>(
                async (selected) =>
                {
                    return (IActionResult)Ok(JsonConvert.SerializeObject(selected.MenuItemAgg.MenuItem));
                },
                async (notSelected) =>
                {
                    return NotFound();
                }
                );
        }

        [HttpGet("restaurant/{restaurantName}/{menuName}/AllMenuItems")]
        public async Task<IActionResult> GetAllMenuItems(String restaurantName, String menuName)
        {
            var getAllMenuItemsExpr = from selectRestaurant in RestaurantDomain.GetRestaurant(restaurantName)
                                      let restaurant = (selectRestaurant as RestaurantSelected)?.RestaurantAgg
                                      from selectMenu in RestaurantDomain.GetMenu(menuName, restaurant.Restaurant.Id)
                                      let menu = (selectMenu as MenuSelected)?.MenuAgg
                                      from getAllMenus in RestaurantDomain.GetAllMenuItems(menu.Menu.Id)
                                      select getAllMenus;

            return Ok(await interpreter.Interpret(getAllMenuItemsExpr, Unit.Default));
        }

        [HttpGet("client/{username}/PaymentStatus")]
        public async Task<IActionResult> GetPaymentStatus(String username)
        {
            var getPaymentExpr = from selectClient in RestaurantDomain.GetClient(username)
                                 let client = (selectClient as ClientSelected)?.ClientAgg
                                 from getPaymentStatus in RestaurantDomain.GetPaymentStatus(client)
                                 let payment = (getPaymentStatus as PaymentStatusGot)?.Status
                                 select getPaymentStatus;

            var result = await interpreter.Interpret(getPaymentExpr, Unit.Default);

            return await result.MatchAsync<IActionResult>(
                async (paymentGot) =>
                {
                    return (IActionResult)Ok(paymentGot.Status);
                },

                async (paymentNotGot) =>
                {
                    return NotFound();
                }
                );
        }

        [HttpPost("CreateClient")]
        public async Task<IActionResult> CreateClient(Client entity)
        {
            var expr = from createEntity in RestaurantDomain.CreateClient(entity)
                       let entityC = (createEntity as ClientCreated)?.ClientAgg
                       select createEntity;

            var result = await interpreter.Interpret(expr, Unit.Default);
            return await result.MatchAsync<IActionResult>(
                async (created) =>
                {
                    await interpreter.Interpret(Database.AddOrUpdateEntity(created.ClientAgg.Client), Unit.Default);
                    return (IActionResult)Ok(created.ClientAgg.Client);
                },
                async (notCreated) =>
                {
                    return NotFound();
                });
        }
    }
}