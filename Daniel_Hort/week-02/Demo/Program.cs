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
                from restaurantResult in RestaurantDomain.CreateRestaurant("McRonald")
                let restaurant = (restaurantResult as RestaurantCreated)?.Restaurant
                from menuRes1 in RestaurantDomain.CreateMenu(restaurant, "Burgers", MenuType.Meat)
                let menu1 = (menuRes1 as MenuCreated)?.Menu
                from menuItemRes1 in RestaurantDomain.CreateMenuItem(menu1, "Tasty", 13)
                from menuItemRes2 in RestaurantDomain.CreateMenuItem(menu1, "Cheese King", 5)
                from menuRes2 in RestaurantDomain.CreateMenu(restaurant, "Drinks", MenuType.Beverages)
                let menu2 = (menuRes2 as MenuCreated)?.Menu
                from menuItemRes3 in RestaurantDomain.CreateMenuItem(menu2, "Pepsi", 7)
                from menuItemRes4 in RestaurantDomain.CreateMenuItem(menu2, "Cola", 7)
                select restaurantResult;

            var interpreter = new LiveInterpreterAsync(serviceProvider);
            var result = await interpreter.Interpret(expr, Unit.Default);
            var finalResult = result.Match(OnRestaurantCreated, OnRestaurantNotCreated);

            var res = finalResult as Restaurant;

            Console.WriteLine("{0}'s Menus", res.Name);
            res.Menus.ForEach(a =>
            {
                Console.WriteLine("\t~{0} [{1}]~", a.Name, a.MenuType);
                a.Items.ForEach(b => Console.WriteLine("\t{0} / {1}", b.Name, b.Price));

            });
        }

        private static object OnRestaurantNotCreated(RestaurantNotCreated arg)
        {
            return arg.Reason;
        }

        private static object OnRestaurantCreated(RestaurantCreated arg)
        {
            return arg.Restaurant;
        }
    }
}
