using System;
using System.Collections.Generic;
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
            
            Ingredient mozarella = new Ingredient("mozarella");
            Ingredient bacon = new Ingredient("bacon");
            List<Ingredient> ingredients = new List<Ingredient>();
            ingredients.Add(mozarella);
            ingredients.Add(bacon);

            var expr =
                from restaurantResult in RestaurantDomain.CreateRestaurant("mcdonalds")
                let restaurant = (restaurantResult as RestaurantCreated)?.Restaurant
                from newMenuResult in RestaurantDomain.CreateMenu(restaurant, "burgers", MenuType.Meat)
                let newMenu= (newMenuResult as MenuCreated)?.Menu
                from menuItemResult in RestaurantDomain.CreateMenuItem(newMenu, "Paste Carbonara", 30, ingredients)
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
