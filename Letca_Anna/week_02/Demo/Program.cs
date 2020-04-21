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
using static Domain.Domain.AddMenuItemOp.AddMenuItemResult;
using static Domain.Domain.CreateClientOp.CreateClientResult;
using static Domain.Domain.CreateMenuItemOp.CreateMenuItemResult;
using static Domain.Domain.CreateMenuOp.CreateMenuResult;
using static Domain.Domain.CreateRestauratOp.CreateRestaurantResult;
using System.Collections.Generic;
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
            string input;

            Storage storage = Storage.GetInstance();


            var expr =
                from restaurantResult in RestaurantDomain.CreateRestaurant("vinto")
                let restaurant = (restaurantResult as RestaurantCreated)?.Restaurant
                from menuResult in RestaurantDomain.CreateMenu(restaurant, "paste", MenuType.Meat)
                let menu = (menuResult as MenuCreated)?.Menu
                from menuItemResult in RestaurantDomain.CreateAndAddMenuItem("carbonara", 100, menu)
                from menuItemResult1 in RestaurantDomain.CreateAndAddMenuItem("carbonara", 25, menu)
                from menuItemResult2 in RestaurantDomain.CreateAndAddMenuItem("conpesto", 20, menu)
                let menuItem2=(menuItemResult2 as MenuItemAdded)?.MenuItem
                from clientResult in RestaurantDomain.CreateClient("gucdg34u6trgfh")
                let client = (clientResult as ClientCreated)?.Client
                from addToCartResult in RestaurantDomain.AddItemToCart(menuItem2, client)
                from orderResult in RestaurantDomain.CreateAndPlaceOrder(client, restaurant)
                select restaurantResult;

            var interpreter = new LiveInterpreterAsync(serviceProvider);

            var result = await interpreter.Interpret(expr, Unit.Default);

            var finalResult = result.Match<bool>(OnRestaurantCreated, OnRestaurantNotCreated);
            Assert.True(finalResult);

            do
            {
                PrintInputOptions();
                input = Console.ReadLine();
                switch (input)
                {
                    case "1": 
                        Console.WriteLine("Type the name...");
                        string name = Console.ReadLine();
                        var getRestaurantExpr =
                                        from restaurant in RestaurantDomain.GetRestaurant(name)
                                        select restaurant;
                        var found = await interpreter.Interpret(getRestaurantExpr, Unit.Default);
                        var foundResult = found.Match<bool>(OnRestaurantFound, OnRestaurantNotFound);
                        Assert.True(foundResult);
                        PrintInputOptions(); 
                        break;
                }
            } while (input != "0");
        }

        private static bool OnRestaurantNotCreated(RestaurantNotCreated arg)
        {
            return false;
        }


        private static bool OnRestaurantCreated(RestaurantCreated arg)
        {
            Console.WriteLine(arg.Restaurant.ToString());
            return true;
        }

        private static bool OnRestaurantNotFound(RestaurantNotFound arg)
        {
            return false;
        }


        private static bool OnRestaurantFound(RestaurantFound arg)
        {
            Console.WriteLine(arg.Restaurant.Name);
            return true;
        }

        private static void PrintInputOptions()
        {
            Console.WriteLine("1. Get Restaurant by Name");
            Console.WriteLine("0. Exit");
        }

    }
}
