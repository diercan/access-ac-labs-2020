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
            // from restaurantResult in RestaurantDomain.CreateRestaurant(null) //Exception -> RestaurantErrorCode.IllegalCharacters
            // from restaurantResult in RestaurantDomain.CreateRestaurant("McDonalds") //Exception -> RestaurantErrorCode.RestaurantExists
            // from restaurantResult in RestaurantDomain.CreateRestaurant("McDonalds►") //Exception -> RestaurantErrorCode.IllegalCharacters
            // from restaurantResult in RestaurantDomain.CreateRestaurant("") //Exception -> RestaurantErrorCode.EmptyField
            var expr =
                from restaurantResult in RestaurantDomain.CreateRestaurant("mcdonalds")
                let restaurant = (restaurantResult as RestaurantCreated)?.Restaurant
                select restaurantResult;

            var interpreter = new LiveInterpreterAsync(serviceProvider);
            var result = await interpreter.Interpret(expr, Unit.Default);

            // dynamic keyword needed to get the result type, error otherwise
            dynamic resultType = result.GetType();

            // If the restaurant was successfully created
            if (resultType.Name == "RestaurantCreated")
            {
                // Restaurant was successfully created
                var resultClass = result as RestaurantCreated;
            } // End RestaurantCreated If
            else
            {
                // Treating all the possible errors
                //var resultClass = result as RestaurantNotCreated;
                //Console.Write("Error! Restaurant was not created because the ");
                //switch (resultClass.Reason)
                //{
                //    case RestaurantErrorCode.NameTooLong:
                //        {
                //            Console.WriteLine($"restaurant name was too long. Please use a name shorter than 256 characters! Error code {resultClass.Reason}");
                //            break;
                //        }
                //    case RestaurantErrorCode.IllegalCharacters:
                //        {
                //            Console.WriteLine($"restaurant name had illegal characters. Error code {resultClass.Reason}");
                //            break;
                //        }
                //    case RestaurantErrorCode.RestaurantExists:
                //        {
                //            Console.WriteLine($"restaurant already exists in the system. Error code {resultClass.Reason}");
                //            break;
                //        }
                //    case RestaurantErrorCode.EmptyField:
                //        {
                //            Console.WriteLine($"restaurant name was empty. Error code {resultClass.Reason}");
                //            break;
                //        }
                //}
            }

            // var restaurantCreated = result as RestaurantCreated; // Assuming we have the createdRestaurant or using an existing restaurant

            // Trying to create a menu
            //var menuExpr = from menuRes in RestaurantDomain.CreateMenu(restaurantCreated.Restaurant, "menuName", MenuType.Meat)
            //               let menu = (menuRes as MenuCreated)?.Menu
            //               select menuRes;

            //var menuResult = await interpreter.Interpret(menuExpr, Unit.Default);
            //if ((dynamic)menuResult.GetType().Name == "MenuCreated")
            //{
            //    //Menu was successfully created
            //}
            //else
            //{
            //    //Menu could not be created. TODO - Cover all the exceptions
            //}

            //// Trying to create an employee
            //var employeeExpr = from employeeRes in RestaurantDomain.CreateEmployee("1", 2, "3", "4", 5.0F, Employee.JobRoles.Cashier, "6", restaurantCreated.Restaurant)
            //                   let employee = (employeeRes as EmployeeCreated)?.Employee
            //                   select employeeRes;

            //var employeeResult = await interpreter.Interpret(employeeExpr, Unit.Default);

            //if ((dynamic)employeeResult.GetType().Name == "EmployeeCreated")
            //{
            //    //Employee was successfully created
            //}
            //else
            //{
            //    //Employee could not be created. TODO - Cover all the exceptions
            //}

            var finalResult = result.Match(OnRestaurantCreated, OnRestaurantNotCreated);
            //.True(finalResult);

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
    }
}