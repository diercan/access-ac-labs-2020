using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Domain;
using Domain.Domain.CreateRestauratOp;
using Domain.Domain.SelectRestaurantOp;
using Domain.Models;
using Infrastructure.Free;
using LanguageExt;
using Microsoft.Extensions.DependencyInjection;
using Xunit;
using static Domain.Domain.AddToCartOp.AddToCartResult;
using static Domain.Domain.ChangeQuantityOp.ChangeQuantityResult;
using static Domain.Domain.CreateEmployeeOp.CreateEmployeeResult;
using static Domain.Domain.CreateMenuItem.CreateMenuItemResult;
using static Domain.Domain.CreateMenuOp.CreateMenuResult;
using static Domain.Domain.CreateOrderOp.CreateOrderResult;
using static Domain.Domain.CreateRestauratOp.CreateRestaurantResult;
using static Domain.Domain.DeleteRestaurantOp.DeleteRestaurantResult;
using static Domain.Domain.GetMenusOp.GetMenusResult;
using static Domain.Domain.GetOrderStatus.GetOrderStatusResult;
using static Domain.Domain.PlaceOrderOp.PlaceOrderResult;
using static Domain.Domain.SelectRestaurantOp.SelectRestaurantResult;
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
                from restaurantResult in RestaurantDomain.SelectRestaurant("McDonalds")
                let restaurant = (restaurantResult as RestaurantSelected)?.Restaurant
                from menuRes in RestaurantDomain.CreateMenu(restaurant, "Chicken", MenuType.Meat)
                let menu = (menuRes as MenuCreated)?.Menu
                from employeeRes in RestaurantDomain.CreateEmployee("1", 2, "3", "4", 5, Employee.JobRoles.Cashier, "6", restaurant)
                let employee = (employeeRes as EmployeeCreated)?.Employee
                from orderRes in RestaurantDomain.CreateOrder(0, 1, null, "waiter", 4F, restaurant)
                let order = (orderRes as OrderCreated)?.Order
                from addMenuItemRes in RestaurantDomain.CreateMenuItem("McChicken", 20, null, new List<string> { "McChicken", "Cartofi prajiti", "Coca Cola" }, null, menu)
                let firstMenuItem = (addMenuItemRes as MenuItemCreated)?.MenuItem
                from addMenuItemRes2 in RestaurantDomain.CreateMenuItem("Cheeseburger", 20, null, new List<string> { "Cheeseburger", "Cartofi prajiti", "Coca Cola" }, null, menu)
                let secondMenuItem = (addMenuItemRes2 as MenuItemCreated)?.MenuItem
                from deleteRestaurantRes in RestaurantDomain.DeleteRestaurant("KFC")
                let dlt = (deleteRestaurantRes as RestaurantDeleted)?.Ok
                from getAllMenus in RestaurantDomain.GetAllMenus(restaurant)
                let allMenus = (getAllMenus as MenusGot)?.Menus
                from addItemToCart in RestaurantDomain.AddToCart("0", AllHardcodedValues.HarcodedVals.CartItems)
                let itemsToCart = (addItemToCart as ItemsAddedToCart)
                from changeItemQuantity in RestaurantDomain.ChangeQuantity("0", AllHardcodedValues.HarcodedVals.CartItems[0], 100)
                let quantityChanged = (changeItemQuantity as QuantityChanged)
                from placeOrder in RestaurantDomain.PlaceOrder(AllHardcodedValues.HarcodedVals.Clients[0], 700)
                let orderPlaced = (placeOrder as OrderPlaced)
                from getOrderStatus in RestaurantDomain.GetOrderStatus("0")
                let getStatus = (getOrderStatus as OrderGot)?.CartStatus
                select restaurantResult;

            //var expr =
            //    from restaurantResult in RestaurantDomain.SelectRestaurant("McDonalds")
            //    let restaurant = (restaurantResult as RestaurantSelected)?.Restaurant
            //    select restaurantResult;

            var interpreter = new LiveInterpreterAsync(serviceProvider);
            var result = await interpreter.Interpret(expr, Unit.Default);

            //var finalResult = result.Match(OnRestaurantCreated, OnRestaurantNotCreated);
            var finalResult = result.Match(OnRestaurantSelected, OnRestaurantNotSelected);

            Console.WriteLine("Hello World!");
        }

        private static ICreateRestaurantResult OnRestaurantNotCreated(RestaurantNotCreated arg)
        {
            Console.WriteLine(arg.Reason);
            return arg;
        }

        private static ICreateRestaurantResult OnRestaurantCreated(RestaurantCreated arg)
        {
            return arg;
        }

        private static ISelectRestaurantResult OnRestaurantSelected(RestaurantSelected arg) => arg;

        private static ISelectRestaurantResult OnRestaurantNotSelected(RestaurantNotSelected arg)
        {
            Console.WriteLine(arg.Reason);
            return arg;
        }

        private static ICreateMenuResult OnMenuCreate(MenuCreated arg) => arg;

        private static ICreateMenuResult OnMenuNotCreate(MenuNotCreated arg)
        {
            Console.WriteLine(arg.Reason);
            return arg;
        }
    }
}