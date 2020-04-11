using System;
using System.Linq;
using System.Threading.Tasks;
using Domain.Domain;
using Domain.Domain.CreateEmployeeOp;
using Domain.Domain.CreateMenuItemOp;
using Domain.Domain.CreateRestauratOp;
using Domain.HardcodedValues;
using Domain.Models;
using Infrastructure.Free;
using LanguageExt;
using Microsoft.Extensions.DependencyInjection;
using Xunit;
using static Domain.Domain.CreateEmployeeOp.CreateEmployeeResult;
using static Domain.Domain.CreateMenuItemOp.CreateMenuItemResult;
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

            var finalResult = result.Match(OnRestaurantCreated, OnRestaurantNotCreated);
            Assert.True(finalResult);


            // User expression
            var userExpr =
                from userResult in RestaurantDomain.CreateUser("Hanz", "HanzPassword", 45)
                let user = (userResult as UserCreated)?.User
                select userResult;

            var userRez = await interpreter.Interpret(userExpr, Unit.Default);

            var userFinalResult = userRez.Match(OnUserCreated, OnUserNotCreated);
            Assert.True(userFinalResult);

            //MenuItem expression
            var menuItemExpresion =
                from menuItemResult in RestaurantDomain.CreateMenuItem(
                    "Pizza", 13.5m, MenuItemValues.getIngredients(), MenuItemValues.getAlergens(), MenuItemValues.getMenu())
                let menuItem = (menuItemResult as MenuItemCreated)?.MenuItem
                select menuItemResult;

            var menuItemRez = await interpreter.Interpret(menuItemExpresion, Unit.Default);

            var manuItemFinalResult = menuItemRez.Match(OnMenuItemCreated, OnMenuItemNotCreated);
            Assert.True(manuItemFinalResult);

            //Employee expression
            var employeeExpr =
                from employeeResult in RestaurantDomain.CreateEmployee("Hanz", "Bauer", 30, "Timisoara nr.45",
                500m, Domain.Models.Gender.Male, Domain.Models.Position.Manager, new Restaurant("Papanasii"))
                let employee = (employeeResult as EmployeeCreated)?.Employee
                select employeeResult;

            var employeeRez = await interpreter.Interpret(employeeExpr, Unit.Default);

            var employeeFinalResult = employeeRez.Match(OnEmployeeCreated, OnEmployeeNotCreated);
            Assert.True(employeeFinalResult);

            Console.WriteLine("Hello World!");
        }

        private static bool OnEmployeeNotCreated(EmployeeNotCreated arg)
        {
            throw new NotImplementedException();
        }

        private static bool OnEmployeeCreated(EmployeeCreated arg)
        {
            throw new NotImplementedException();
        }

        private static bool OnMenuItemNotCreated(MenuItemNotCreated arg)
        {
            throw new NotImplementedException();
        }

        private static bool OnMenuItemCreated(MenuItemCreated arg)
        {
            throw new NotImplementedException();
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
