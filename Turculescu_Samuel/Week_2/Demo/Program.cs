using System;
using System.Linq;
using System.Threading.Tasks;
using Domain.Domain;
using Domain.Domain.CreateRestaurantOp;
using Domain.Models;
using Infrastructure.Free;
using LanguageExt;
using Microsoft.Extensions.DependencyInjection;
using Xunit;
using static Domain.Domain.CreateRestaurantOp.CreateRestaurantResult;
using static Domain.Domain.CreateClientOp.CreateClientResult;
using static Domain.Domain.EmployeeRoles.CreateMenuOp.CreateMenuResult;
using Microsoft.CodeAnalysis.VisualBasic.Syntax;
using System.Collections.Generic;
using Domain.Domain.ClientRoles.GetRestaurantOp;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Domain.Domain.CreateClientOp;
using static Domain.Domain.ClientRoles.GetRestaurantOp.GetRestaurantResult;
using static Domain.Domain.ClientRoles.GetMenusOp.GetMenusResult;

namespace Demo
{
    class Program
    {      

        static async Task Main(string[] args)
        {
             

        var serviceCollection = new ServiceCollection();
            serviceCollection.AddOperations(typeof(Restaurant).Assembly);
            var serviceProvider = serviceCollection.BuildServiceProvider();            

            var exprRestaurant01 =
                from restaurantResult in RestaurantDomain.CreateRestaurant("McDonalds", "Piata Victoriei")
                let restaurant = (restaurantResult as RestaurantCreated)?.Restaurant
                from MenuResult1 in RestaurantDomain.CreateMenu(restaurant, "Burgers")
                let Menu1 = (MenuResult1 as MenuCreated)?.Menu
                from newMenu1Item01 in RestaurantDomain.CreateMenuItem(Menu1, "McChicken", 5.00, 100, "list of ingredients", "list of allergens", MenuItemState.Available)
                from newMenu1Item02 in RestaurantDomain.CreateMenuItem(Menu1, "BigMac", 10.00, 100, "list of ingredients", "list of allergens", MenuItemState.Available)
                from newMenu1Item03 in RestaurantDomain.CreateMenuItem(Menu1, "Cheeseburger", 5.50, 100, "list of ingredients", "list of allergens", MenuItemState.Available)
                from MenuResult2 in RestaurantDomain.CreateMenu(restaurant, "Beverages")
                let Menu2 = (MenuResult2 as MenuCreated)?.Menu
                from newMenu2Item01 in RestaurantDomain.CreateMenuItem(Menu2, "Coca-Cola", 5.00, 100, "list of ingredients", "list of allergens", MenuItemState.Available)
                from newMenu2Item02 in RestaurantDomain.CreateMenuItem(Menu2, "Sprite", 5.00, 100, "list of ingredients", "list of allergens", MenuItemState.Available)
                from newMenu2Item03 in RestaurantDomain.CreateMenuItem(Menu2, "Apple Juice", 7.00, 100, "list of ingredients", "list of allergens", MenuItemState.Available)
                from Employee01 in RestaurantDomain.CreateEmployee("Waiter", "01", "waiter01@restaurant.com", "07xxxxxxxx", "waiter01", restaurant)
                from Employee02 in RestaurantDomain.CreateEmployee("Chef", "01", "chef01@restaurant.com", "07xxxxxxxx", "chef01", restaurant)
                select restaurantResult;
            
            var exprRestaurant02 =
                from restaurantResult in RestaurantDomain.CreateRestaurant("3F", "Piata Victoriei")
                let restaurant = (restaurantResult as RestaurantCreated)?.Restaurant
                from MenuResult1 in RestaurantDomain.CreateMenu(restaurant, "Soups")
                let Menu1 = (MenuResult1 as MenuCreated)?.Menu
                from newMenu1Item01 in RestaurantDomain.CreateMenuItem(Menu1, "Chicken Soup", 12.00, 150, "list of ingredients", "list of allergens", MenuItemState.Available)
                from newMenu1Item02 in RestaurantDomain.CreateMenuItem(Menu1, "Beef Soup", 10.00, 100, "list of ingredients", "list of allergens", MenuItemState.Available)
                from MenuResult2 in RestaurantDomain.CreateMenu(restaurant, "Beverages")
                let Menu2 = (MenuResult2 as MenuCreated)?.Menu
                from newMenu2Item01 in RestaurantDomain.CreateMenuItem(Menu2, "Coca-Cola", 5.00, 300, "list of ingredients", "list of allergens", MenuItemState.Available)
                from newMenu2Item02 in RestaurantDomain.CreateMenuItem(Menu2, "Sprite", 5.00, 200, "list of ingredients", "list of allergens", MenuItemState.Available)
                from newMenu2Item03 in RestaurantDomain.CreateMenuItem(Menu2, "Pepsi", 5.00, 200, "list of ingredients", "list of allergens", MenuItemState.Available)
                from Employee01 in RestaurantDomain.CreateEmployee("Waiter", "01", "waiter01@restaurant.com", "07xxxxxxxx", "waiter01", restaurant)
                from Employee02 in RestaurantDomain.CreateEmployee("Chef", "01", "chef01@restaurant.com", "07xxxxxxxx", "chef01", restaurant)
                select restaurantResult;
            
            var exprClient01 =
                from clientResult in RestaurantDomain.CreateClient("First", "Client", "firstclient@gmail.com", "07xxxxxxxx", "xxxx xxxx xxxx xxxx", "client01")
                let client = (clientResult as ClientCreated)?.Client
                select clientResult;            

            var exprClient02 =
                from clientResult in RestaurantDomain.CreateClient("Second", "Client", "secondclient@gmail.com", "07xxxxxxxx", "xxxx xxxx xxxx xxxx", "client02")
                let client = (clientResult as ClientCreated)?.Client
                select clientResult;

            var interpreter = new LiveInterpreterAsync(serviceProvider);

            var resultRestaurant01 = await interpreter.Interpret(exprRestaurant01, Unit.Default);
            var finalResultRestaurant01 = resultRestaurant01.Match(OnRestaurantCreated, OnRestaurantNotCreated);
            Assert.True(finalResultRestaurant01);

            var resultRestaurant02 = await interpreter.Interpret(exprRestaurant02, Unit.Default);
            var finalResultRestaurant02 = resultRestaurant02.Match(OnRestaurantCreated, OnRestaurantNotCreated);
            Assert.True(finalResultRestaurant02);
            
            /*var resultClient01 = await interpreter.Interpret(exprClient01, Unit.Default);
            var finalResultClient01 = resultClient01.Match<bool>(OnClientCreated, OnClientNotCreated);
            Assert.True(finalResultClient01);
            
            var resultClient02 = await interpreter.Interpret(exprClient02, Unit.Default);
            var finalResultClient02 = resultClient02.Match<bool>(OnClientCreated, OnClientNotCreated);
            Assert.True(finalResultClient02);*/
            

            //MENU
            Console.WriteLine("Welcome to Order And Pay");
            Console.WriteLine("Please choose one from the following commands:");
            Console.WriteLine("1. Show restaurant");
            //Console.WriteLine("2. Get menus");
            //Console.WriteLine("3. Add to cart");
            Console.WriteLine("0. Exit");

            int k;
            while ((k = Console.Read()) != 0)
            {
                switch (k)
                {
                    case 49:
                        {
                            foreach (var r in Storage.RestaurantsList)
                            {
                                Console.WriteLine(r.Name);
                            }
                            break;
                        }
                    case 48:
                        return;
                     //   Console.WriteLine("Command does not exists!");
                        //return;
                }
            }
        }

        private static bool OnRestaurantNotFound(GetRestaurantResult.GetRestaurantNotSuccessful arg)
        {
            return false;
        }

        private static bool OnRestaurantFound(GetRestaurantResult.GetRestaurantSuccessful arg)
        {
            return true;
        }

        private static bool OnClientNotCreated(ClientNotCreated arg)
        {
            return false;
        }

        private static bool OnClientCreated(ClientCreated arg)
        {
            return true;
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
