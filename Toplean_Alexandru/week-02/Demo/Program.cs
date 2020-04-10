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
using static Domain.Domain.CreateEmployeeOp.CreateEmployeeResult;
using static Domain.Domain.CreateMenuOp.CreateMenuResult;
using static Domain.Domain.CreateOrderOp.CreateOrderResult;
using static Domain.Domain.CreateRestauratOp.CreateRestaurantResult;
using static Domain.Models.Restaurant;

namespace Demo
{
    internal class Program
    {
        private static async Task Main(string[] args)
        {
            var serviceCollection = new ServiceCollection();
            serviceCollection.AddOperations(typeof(Restaurant).Assembly);
            var serviceProvider = serviceCollection.BuildServiceProvider();
            // from restaurantResult in RestaurantDomain.CreateRestaurant(null) //Exception -> RestaurantErrorCode.UnknownError
            // from restaurantResult in RestaurantDomain.CreateRestaurant("McDonalds") //Exception -> RestaurantErrorCode.RestaurantExists
            // from restaurantResult in RestaurantDomain.CreateRestaurant("McDonalds►") //Exception -> RestaurantErrorCode.IllegalCharacters
            // from restaurantResult in RestaurantDomain.CreateRestaurant("") //Exception -> RestaurantErrorCode.EmptyField
            var expr =
                from restaurantResult in RestaurantDomain.CreateRestaurant("McDoonalds")
                let restaurant = (restaurantResult as RestaurantCreated)?.Restaurant
                from menuRes in RestaurantDomain.CreateMenu(restaurant, "mc", MenuType.Meat)
                let menu = (menuRes as MenuCreated)?.Menu
                from employeeRes in RestaurantDomain.CreateEmployee("1", 2, "3", "4", 5, Employee.JobRoles.Cashier, "6", restaurant)
                let employee = (employeeRes as EmployeeCreated)?.Employee
                from orderRes in RestaurantDomain.CreateOrder(0, 1, null, "waiter", 4F, restaurant)
                let order = (orderRes as OrderCreated)?.Order
                select restaurantResult;

            var interpreter = new LiveInterpreterAsync(serviceProvider);
            var result = await interpreter.Interpret(expr, Unit.Default);

            var finalResult = result.Match(OnRestaurantCreated, OnRestaurantNotCreated);

            Console.WriteLine("Hello World!");
        }

        private static ICreateRestaurantResult OnRestaurantNotCreated(RestaurantNotCreated arg)
        {
            switch (arg.Reason)
            {
                case RestaurantErrorCode.NameTooLong:
                    {
                        Console.WriteLine($"restaurant name was too long. Please use a name shorter than 256 characters! Error code {arg.Reason}");
                        break;
                    }
                case RestaurantErrorCode.IllegalCharacters:
                    {
                        Console.WriteLine($"restaurant name had illegal characters. Error code {arg.Reason}");
                        break;
                    }
                case RestaurantErrorCode.RestaurantExists:
                    {
                        Console.WriteLine($"restaurant already exists in the system. Error code {arg.Reason}");
                        break;
                    }
                case RestaurantErrorCode.EmptyField:
                    {
                        Console.WriteLine($"restaurant name was empty. Error code {arg.Reason}");
                        break;
                    }
                case RestaurantErrorCode.UnknownError:
                    {
                        Console.WriteLine($"an unknown error occured. Error code {arg.Reason}");
                        break;
                    }
            }
            return arg;
        }

        private static ICreateRestaurantResult OnRestaurantCreated(RestaurantCreated arg)
        {
            return arg;
        }

        private static ICreateMenuResult OnMenuCreate(MenuCreated arg) => arg;

        private static ICreateMenuResult OnMenuNotCreate(MenuNotCreated arg)
        {
            switch (arg.Reason)
            {
                case MenuErrorCode.EmptyField:
                    {
                        Console.WriteLine($"text field is empty. Please use a name shorter than 256 characters! Error code {arg.Reason}");
                        break;
                    }
                case MenuErrorCode.UnknownError:
                    {
                        Console.WriteLine($"Unknown reason. Error code {arg.Reason}");
                        break;
                    }
                case MenuErrorCode.ExistentMenu:
                    {
                        Console.WriteLine($"menu already exists in the system. Error code {arg.Reason}");
                        break;
                    }
            }
            return arg;
        }
    }
}