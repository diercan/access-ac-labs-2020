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
                from restaurantResult in RestaurantDomain.CreateRestaurant("")
                let restaurant = (restaurantResult as RestaurantCreated)?.Restaurant
                from menuResult in RestaurantDomain.CreateMenu(restaurant, "paste", MenuType.Meat)
                let menu = (menuResult as MenuCreated)?.Menu
                from menuItemResult in RestaurantDomain.CreateAndAddMenuItem("carbonara", 100, menu)
                from menuItemResult1 in RestaurantDomain.CreateAndAddMenuItem("carbonara", 25, menu)
                from menuItemResult2 in RestaurantDomain.CreateAndAddMenuItem("conpesto", 20, menu)
                from clientResult in RestaurantDomain.CreateClient("gucdg34u6trgfh")
                select restaurantResult;

            //create client(nume)
            //add item to client cart(item, client.cart)
            //remove item from cart(item, client.cart)
            //create and place order(restaurant)

            Console.WriteLine(expr);

            var interpreter = new LiveInterpreterAsync(serviceProvider);

            var result = await interpreter.Interpret(expr, Unit.Default);

            var finalResult = result.Match<bool>(OnRestaurantCreated, OnEmptyNameRestaurantNotCreated);
            Assert.False(finalResult);

        }

        private static bool OnEmptyNameRestaurantNotCreated(EmptyNameRestaurantNotCreated arg)
        {
            return false;
        }


        private static bool OnRestaurantCreated(RestaurantCreated arg)
        {
            Console.WriteLine(arg.Restaurant.ToString());
            return true;
        }

    }
}
