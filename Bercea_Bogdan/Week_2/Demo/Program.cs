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
using static Domain.Domain.CreateUserOp.CreateUserResult;

namespace Demo
{
    class Program
    {
        static async Task Main(string[] args)
        {
            var serviceCollection = new ServiceCollection();
            serviceCollection.AddOperations(typeof(Restaurant).Assembly);
            serviceCollection.AddOperations(typeof(User).Assembly);
            var serviceProvider = serviceCollection.BuildServiceProvider();

            var expr =
                from restaurantResult in RestaurantDomain.CreateRestaurant("mcdonalds")
                let restaurant = (restaurantResult as RestaurantCreated)?.Restaurant
                from newMenu in RestaurantDomain.CreateMenu(restaurant, "burgers", MenuType.Meat)
                select restaurantResult;

            var interpreter = new LiveInterpreterAsync(serviceProvider);

            var result = await interpreter.Interpret(expr, Unit.Default);

            var finalResult = result.Match<bool>(OnRestaurantCreated, OnRestaurantNotCreated);
            Assert.True(finalResult);

            var userExpr =
                from userResult in RestaurantDomain.CreateUser("Hanz", "HanzPassword", 45)
                let user = (userResult as UserCreated)?.User
                select userResult;

            var userRez = await interpreter.Interpret(userExpr, Unit.Default);

            var userFinalResult = userRez.Match<bool>(OnUserCreated, OnUserNotCreated);
            Assert.True(userFinalResult);

            Console.WriteLine("Hello World!");
        }

        private static bool OnUserCreated(UserCreated arg)
        {
            return true;
        }

        private static bool OnUserNotCreated(UserNotCreated arg)
        {
            return false;
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
