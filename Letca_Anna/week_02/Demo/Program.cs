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
using static Domain.Domain.GetRestaurantOp.GetRestaurantResult;
using static Domain.Domain.GetMenuOp.GetMenuResult;
using Domain.Domain.GetMenuOp;
using static Domain.Domain.GetClientOp.GetClientResult;
using static Domain.Domain.GetMenuItemResult.MenuItemResult;
using static Domain.Domain.AddItemToCartOp.AddItemToCartResult;

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
                from clientResult in RestaurantDomain.CreateClient("gucdg34u6trgfh","Anca")
                //from orderResult in RestaurantDomain.CreateAndPlaceOrder(client, restaurant)
                select restaurantResult;

            var interpreter = new LiveInterpreterAsync(serviceProvider);

            var result = await interpreter.Interpret(expr, Unit.Default);

            var finalResult = result.Match<bool>(OnRestaurantCreated, OnRestaurantNotCreated);
            Assert.True(finalResult);

            Restaurant foundRestaurant=null;
            Menu foundMenu = null;
            Client foundClient = null;

            do
            {
                PrintInputOptions();
                input = Console.ReadLine(); 
                switch (input)
                {
                    case "1": // login (suppose client is already created/registered)
                        var getClientExpr =
                                        from client in RestaurantDomain.GetClient("gucdg34u6trgfh")
                                        select client;
                        var interpretedClient = await interpreter.Interpret(getClientExpr, Unit.Default);
                        foundClient = (interpretedClient as ClientFound)?.Client;
                        var clientResponse = interpretedClient.Match<bool>(OnClientFound, OnClientNotFound);
                        break;
                    case "2": //get restauraant
                        Console.WriteLine("Enter the restaurant's name...");
                        string restaurantName = Console.ReadLine();
                        var getRestaurantExpr =
                                        from restaurant in RestaurantDomain.GetRestaurant(restaurantName)
                                        select restaurant;
                        var interpretedRestaurant = await interpreter.Interpret(getRestaurantExpr, Unit.Default);
                        foundRestaurant = (interpretedRestaurant as RestaurantFound)?.Restaurant;
                        var restaurantResponse = interpretedRestaurant.Match<bool>(OnRestaurantFound, OnRestaurantNotFound);
                        break;
                    case "3": //get menu
                        var getMenuExpr =
                                        from menu in RestaurantDomain.GetMenu(foundRestaurant)
                                        select menu;
                        var interpretedMenu = await interpreter.Interpret(getMenuExpr, Unit.Default);
                        foundMenu = (interpretedMenu as MenuFound)?.Menu;
                        var menuResponse = interpretedMenu.Match<bool>(OnMenuFound, OnMenuNotFound); 
                        break;
                    case "4": //add item to cart
                        Console.WriteLine("Enter the menuitem's name...");
                        string itemName = Console.ReadLine();
                        var getItemAndAddToCartExpr =
                                        from item in RestaurantDomain.GetItemAndAddToCart(itemName, foundMenu, foundClient)
                                        select item;
                        var interpretedItem = await interpreter.Interpret(getItemAndAddToCartExpr, Unit.Default);
                        var itemResponse = interpretedItem.Match<bool>(OnItemAdded, OnItemNotAdded);
                        break;
                }
            } while (input != "0");
        }
        private static bool OnItemNotAdded(ItemNotAddedToCart arg)
        {
            return false;
        }


        private static bool OnItemAdded(ItemAddedToCart arg)
        {
            Console.WriteLine(arg.MenuItem.Name + " added to cart.");
            return true;
        }

        private static bool OnClientNotFound(ClientNotFound arg)
        {
            return false;
        }


        private static bool OnClientFound(ClientFound arg)
        {
            Console.WriteLine("Welcome, " + arg.Client.Name + "!");
            return true;
        }

        private static bool OnMenuNotFound(MenuNotFound arg)
        {
            return false;
        }


        private static bool OnMenuFound(MenuFound arg)
        {
            Console.WriteLine(arg.Menu.ToString());
            return true;
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
            Console.WriteLine("1. Authenticate"); 
            Console.WriteLine("2. Get Restaurant by Name");
            Console.WriteLine("3. Get Restaurant's Menu");
            Console.WriteLine("4. Add item to cart");
            Console.WriteLine("0. Exit");
        }

    }
}
