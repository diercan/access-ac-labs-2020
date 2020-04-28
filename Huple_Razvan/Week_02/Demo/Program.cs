using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Domain;
using Domain.Domain.AddToCartOp;
using Domain.Domain.CreateMenuItemOp;
using Domain.Domain.CreateMenuOp;
using Domain.Domain.CreateRestauratOp;
using Domain.Models;
using Infrastructure.Free;
using LanguageExt;
using Microsoft.Extensions.DependencyInjection;
using Xunit;
using static Domain.Domain.CreateMenuOp.CreateMenuResult;
using static Domain.Domain.CreateRestauratOp.CreateRestaurantResult;
using static Domain.Domain.GetClientOp.GetClientResult;
using static Domain.Domain.GetMenuItemOp.GetMenuItemResult;
using static Domain.Domain.GetMenusOp.GetMenusResult;
using static Domain.Domain.GetRestaurantOp.GetRestaurantResult;

namespace Demo
{
    class Program
    {
        static async Task Main(string[] args)
        {
            var serviceCollection = new ServiceCollection();
            serviceCollection.AddOperations(typeof(Restaurant).Assembly);
            var serviceProvider = serviceCollection.BuildServiceProvider();

            var expr =
                from restaurantResult in RestaurantDomain.CreateRestaurant("mcdonalds")
                let restaurant = (restaurantResult as RestaurantCreated)?.Restaurant
                from newMenu in RestaurantDomain.CreateMenu(restaurant, "burgers", MenuType.Meat)
                let menu = (newMenu as MenuCreated)?.Menu
                from menuItem1 in RestaurantDomain.CreateMenuItem(menu, "mcpuisor", 5, new List<string>() { "pui", "sos", "castraveti" })
                from menuItem2 in RestaurantDomain.CreateMenuItem(menu, "cheeseburger", 5, new List<string>() { "vita", "sos", "branza" })
                select menuItem2;

            var interpreter = new LiveInterpreterAsync(serviceProvider);

            var result = await interpreter.Interpret(expr, Unit.Default);
            var r =
                result.Match(
                    created =>
                    {
                        Console.WriteLine("Menu Item:"+created.MenuItem.Title+" was created");
                        return created;
                    },
                    notCreated => 
                    {
                        Console.WriteLine($"Menu item failed because {notCreated.Reason}");
                        return notCreated;
                    });
            //var finalResult = result.Match<bool>(OnRestaurantCreated, OnRestaurantNotCreated);
            //Assert.True(finalResult);
            var expr2 =
                from restaurant in RestaurantDomain.GetRestaurant("mcdonalds")
                select restaurant;
            var interpreter2 = new LiveInterpreterAsync(serviceProvider);
            var result2 = await interpreter.Interpret(expr2, Unit.Default);
            var r2 =
                result2.Match(
                    Found =>
                    {
                        Console.WriteLine("Restaurant:" + Found.Restaurant.Name + " was found");
                        return Found;
                    },
                    notFound =>
                    {
                        Console.WriteLine($"Restaurant not found because {notFound.Reason}");
                        return notFound;
                    }
                    );
            var expr3 =
                from restaurant in RestaurantDomain.GetRestaurant("mcdonalds")
                let restaurant2 = (restaurant as RestaurantFound)?.Restaurant
                from menu in RestaurantDomain.GetMenus(restaurant2,"burgers")
                let menu2 = (menu as MenuFound)?.Menu
                from item in RestaurantDomain.GetMenuItem(menu2,"mcpuisor")
                let item2 = (item as MenuItemGot)?.MenuItem
                from client in RestaurantDomain.GetClient("gicu")
                let client2 = (client as ClientFound)?.Client
                from addcart in RestaurantDomain.AddToCart("",client2,item2,2)
                select addcart;
            var interpreter3 = new LiveInterpreterAsync(serviceProvider);
            var result3 = await interpreter.Interpret(expr3, Unit.Default);
            var r3 =
                 result3.Match(
                     Succesful =>
                     {
                         Console.WriteLine("item successfully added to cart:"+Succesful.Cart);
                         return Succesful;
                     },
                     NotSuccesful =>
                     {
                         Console.WriteLine("couldn't add to cart because:" + NotSuccesful.Reason + " was found");
                         return NotSuccesful;
                     },
                     InvalidRequest =>
                     {
                         Console.WriteLine("couldn't add to cart because:" + InvalidRequest.Reason + " was found");
                         return InvalidRequest;
                     }
                     );
        }

        private static bool OnRestaurantNotCreated(RestaurantNotCreated arg)
        {
            return false;
        }

        private static bool OnRestaurantCreated(RestaurantCreated arg)
        {
            return true;
        }
    }
}
