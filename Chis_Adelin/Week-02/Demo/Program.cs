using System;
using System.Linq;
using System.Threading.Tasks;
using Domain.Domain;
using Domain.Domain.CreateRestauratOp;
using Domain.Models;
using Infrastructure.Free;
using LanguageExt;
using Microsoft.Extensions.DependencyInjection;
using Xunit;
using static Domain.Domain.CreateRestauratOp.CreateRestaurantResult;
using static Domain.Domain.CreateMenuOp.CreateMenuResult;

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
            from menuRes1 in RestaurantDomain.CreateMenu(restaurant, "burgers", MenuType.Meat)
            let menu1 = (menuRes1 as MenuCreated)?.Menu
            from menuItemRes1 in RestaurantDomain.CreateMenuItem(menu1, "Tasty", 13)
            from menuItemRes2 in RestaurantDomain.CreateMenuItem(menu1, "Chicken", 5)
            from menuRes2 in RestaurantDomain.CreateMenu(restaurant, "Drinks", MenuType.Beverages)
            let menu2 = (menuRes2 as MenuCreated)?.Menu
            from menuItemRes3 in RestaurantDomain.CreateMenuItem(menu2, "Pepsi","ingredients bla bla", "allergens", 10)
            from menuItemRes4 in RestaurantDomain.CreateMenuItem(menu2, "Fanta", "ingredients bla bla", "allergens", 12)
            select restaurantResult;

            var interpreter = new LiveInterpreterAsync(serviceProvider);
            var result = await interpreter.Interpret(expr, Unit.Default);
            var finalResult = result.Match<bool>(OnRestaurantCreated, OnRestaurantNotCreated);
            Assert.True(finalResult);

            Console.WriteLine("Hello World!");
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
