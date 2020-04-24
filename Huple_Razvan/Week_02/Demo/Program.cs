using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Domain;
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
