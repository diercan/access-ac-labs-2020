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
using static Domain.Domain.CreateMenuItemOp.CreateMenuItemResult;
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
                from menuResult in RestaurantDomain.CreateMenu(restaurant, "burgers", MenuType.Meat)
                let menu = (menuResult as MenuCreated)?.Menu
                from menuItemResult in RestaurantDomain.CreateMenuItem(menu, "carbonara",50)
                //from menuItemResult in RestaurantDomain.CreateMenuItem(menu, "carbonara", 20)
                select menuItemResult;

            var interpreter = new LiveInterpreterAsync(serviceProvider);

            var result = await interpreter.Interpret(expr, Unit.Default);

            var finalResult = result.Match<bool>(OnMenuItemCreated, OnMenuItemNotCreated);
            Assert.False(finalResult);
            //Assert.True(finalResult);

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

        private static bool OnMenuItemNotCreated(MenuItemNotCreated arg)
        {
            return false;
        }

        private static bool OnMenuItemCreated(MenuItemCreated arg)
        {
            return true;
        }

    }
}
