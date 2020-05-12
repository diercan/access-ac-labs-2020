using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Domain.Domain;
using Domain.Domain.SelectRestaurantOp;
using Domain.Domain.UpdateEntityOp;
using Domain.Entities;
using Domain.Models;
using Infrastructure.Free;
using LanguageExt;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Persistence;
using Persistence.EfCore;
using static Domain.Domain.CreateMenuItemOp.CreateMenuItemResult;
using static Domain.Domain.CreateMenuOp.CreateMenuResult;
using static Domain.Domain.CreateRestauratOp.CreateRestaurantResult;
using static Domain.Domain.DeleteOrderOp.DeleteOrderResult;
using static Domain.Domain.GetPaymentStatusOp.GetPaymentStatusResult;
using static Domain.Domain.PopulateRestaurantOp.PopulateRestaurantResult;
using static Domain.Domain.RequestPaymentOp.RequestPaymentResult;
using static Domain.Domain.SelectClientOp.SelectClientResult;
using static Domain.Domain.SelectMenuItemOp.SelectMenuItemResult;
using static Domain.Domain.SelectMenuOp.SelectMenuResult;
using static Domain.Domain.SelectRestaurantOp.SelectRestaurantResult;
using static Domain.Domain.UpdateClientOp.UpdateClientResult;
using static Domain.Domain.UpdateEntityOp.UpdateEntityResult;

namespace OrderAndPay.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly LiveInterpreterAsync interpreter;

        public EmployeeController(LiveInterpreterAsync interpreter)
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

        [HttpGet("orders/{restaurantName}/All")]
        public async Task<IActionResult> GetAllOrders(String restaurantName)
        {
            var expr = from selectRestaurant in RestaurantDomain.GetRestaurant(restaurantName)
                       let restaurant = (selectRestaurant as RestaurantSelected)?.RestaurantAgg
                       from getAllOrders in RestaurantDomain.GetAllOrdersItems(restaurant.Restaurant.Id)

                       select getAllOrders;

            return (IActionResult)Ok(await interpreter.Interpret(expr, Unit.Default));
        }

        [HttpPost("CreateRestaurant")]
        public async Task<IActionResult> CreateRestaurant([Bind("Name")]Restaurant entity)
        {
            var expr = from createEntity in RestaurantDomain.CreateRestaurant(entity)
                       let entityC = (createEntity as RestaurantCreated)?.RestaurantAgg
                       select createEntity;

            var result = await interpreter.Interpret(expr, Unit.Default);
            return await result.MatchAsync<IActionResult>(
                async (created) =>
                {
                    await interpreter.Interpret(Database.AddOrUpdateEntity(created.RestaurantAgg.Restaurant), Unit.Default);
                    return (IActionResult)Ok(created.RestaurantAgg.Restaurant);
                },
                async (notCreated) =>
                {
                    return BadRequest();
                });
        }

        [HttpPost("CreateMenu/{RestaurantID}")]
        public async Task<IActionResult> CreateMenu(int RestaurantID, [Bind("Name,MenuType,Visibility,Hours")] Menu entity)
        {
            entity.RestaurantId = RestaurantID;

            var expr = from createEntity in RestaurantDomain.CreateMenu(entity)
                       let entityC = (createEntity as MenuCreated)?.Menu

                       select createEntity;

            var result = await interpreter.Interpret(expr, Unit.Default);
            return await result.MatchAsync<IActionResult>(
                async (created) =>
                {
                    await interpreter.Interpret(Database.AddOrUpdateEntity(created.Menu.Menu), Unit.Default);
                    return (IActionResult)Ok(created.Menu.Menu);
                },
                async (notCreated) =>
                {
                    return BadRequest();
                });
        }

        [HttpPost("CreateMenuItem/{MenuID}")]
        public async Task<IActionResult> CreateMenuItem(int MenuID, [Bind("Name,Ingredients,Alergens,Price,Image")]MenuItem entity)
        {
            entity.MenuId = MenuID;
            var expr = from createEntity in RestaurantDomain.CreateMenuItem(entity)
                       let entityC = (createEntity as MenuItemCreated)?.MenuItemAgg

                       select createEntity;

            var result = await interpreter.Interpret(expr, Unit.Default);
            return await result.MatchAsync<IActionResult>(
                async (created) =>
                {
                    await interpreter.Interpret(Database.AddOrUpdateEntity(created.MenuItemAgg.MenuItem), Unit.Default);
                    return (IActionResult)Ok(created.MenuItemAgg.MenuItem);
                },
                async (notCreated) =>
                {
                    return BadRequest();
                });
        }

        [HttpPost("RequestPayment/{username}")]
        public async Task<IActionResult> RequestPayment(String username)
        {
            var expr = from getClient in RestaurantDomain.GetClient(username)
                       let client = (getClient as ClientSelected).ClientAgg
                       from requestPayment in RestaurantDomain.RequestPayment(client)
                       let newClient = (requestPayment as PaymentRequested)?.ClientAgg
                       from updateClient in RestaurantDomain.UpdateAndPersistClient(newClient.Client)
                       let updated = (updateClient as ClientUpdated)?.ClientAgg.Client
                       select updateClient;

            var updateRestaurantFin = await interpreter.Interpret(expr, Unit.Default);

            return updateRestaurantFin.Match(
                updated =>
                {
                    return (IActionResult)Ok(updated);
                },
                notUpdated =>
                {
                    return BadRequest();
                }
                );
        }

        [HttpDelete("DeleteOrder/{orderID}")]
        public async Task<IActionResult> DeteleOrder(int orderID)
        {
            var expr = from deleteOrder in RestaurantDomain.DeleteOrderFromDB(orderID)
                       let order = (deleteOrder as OrderDeleted)?.Order
                       select deleteOrder;

            var result = await interpreter.Interpret(expr, Unit.Default);
            return await result.MatchAsync<IActionResult>(

                async (deleted) =>
                {
                    return (IActionResult)Ok(deleted.Order);
                },
                async (notDeleted) =>
                {
                    return BadRequest();
                }

                );
        }
    }
}