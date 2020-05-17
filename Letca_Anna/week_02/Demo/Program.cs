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
using Infra.Persistence;
using Infra.Free;
using Persistence.EfCore.Operations;
using Persistence.EfCore;
using Persistence.EfCore.Context;
using System.Collections.Generic;

namespace Demo
{
    class Program
    {
        static async Task Main(string[] args)
        {
            var serviceCollection = new ServiceCollection();
            serviceCollection.AddOperations(typeof(RestaurantAgg).Assembly);
            serviceCollection.AddOperations(typeof(AddOrUpdateOp).Assembly);
            serviceCollection.AddTransient(typeof(IOp<,>), typeof(QueryOp<,>));

            serviceCollection.AddDbContext<OrderAndPayContext>(ServiceLifetime.Singleton);

            var serviceProvider = serviceCollection.BuildServiceProvider();
            string input;

            Storage storage = Storage.GetInstance();


            /*var expr =
                from restaurantResult in RestaurantDomain.CreateRestaurantAndPersist("vinto")
                let restaurant = (restaurantResult as RestaurantCreated)?.RestaurantAgg
                from restaurantResult2 in RestaurantDomain.CreateRestaurantAndPersist("urban")
                let restaurant2 = (restaurantResult2 as RestaurantCreated)?.RestaurantAgg
                from pasteResult in RestaurantDomain.CreateMenuAndPersist(restaurant, "paste", MenuType.Meat)
                from burgeriResult in RestaurantDomain.CreateMenuAndPersist(restaurant, "burgeri", MenuType.Meat)
                from pizzaResult in RestaurantDomain.CreateMenuAndPersist(restaurant, "pizza", MenuType.Meat)
                let paste = (pasteResult as MenuCreated)?.Menu
                from menuItemResult in RestaurantDomain.CreateMenuItemAndPersist("carbonara", 50, paste)
                from menuItemResult1 in RestaurantDomain.CreateMenuItemAndPersist("conpesto", 25, paste)
                let burgeri = (burgeriResult as MenuCreated)?.Menu
                from menuItemResult2 in RestaurantDomain.CreateMenuItemAndPersist("beefburger", 20, burgeri)
                //from clientResult in RestaurantDomain.CreateClient("gucdg34u6trgfh","Anca")
                //from orderResult in RestaurantDomain.CreateAndPlaceOrder(client, restaurant)
                select restaurantResult;

            var interpreter = new LiveInterpreterAsync(serviceProvider);

            var result = await interpreter.Interpret(expr, Unit.Default);

            var finalResult = result.Match<bool>(OnRestaurantCreated, OnRestaurantNotCreated);
            Assert.True(finalResult);

            Restaurant foundRestaurant=null;
            List<Menus> foundMenus = null;
            //Client foundClient = null;

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
                        foundRestaurant = (interpretedRestaurant as RestaurantFound)?.RestaurantAgg.Restaurant;
                        var restaurantResponse = interpretedRestaurant.Match<bool>(OnRestaurantFound, OnRestaurantNotFound);
                        break;
                    case "3": //get menu
                        var getMenuExpr =
                                        from menu in RestaurantDomain.GetMenu(foundRestaurant)
                                        select menu;
                        var interpretedMenu = await interpreter.Interpret(getMenuExpr, Unit.Default);
                        foundMenus = (interpretedMenu as MenuFound)?.Menus;
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
            } while (input != "0"); */
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
            Console.WriteLine(arg.Reason);
            return false;
        }


        private static bool OnMenuFound(MenuFound arg)
        {
            arg.Menus.Iter(menu => menu.MenuItems.Iter(item=>Console.WriteLine(item.Name+", price: " + item.Price)));
            return true;
        }

        private static bool OnRestaurantNotCreated(RestaurantNotCreated arg)
        {
            return false;
        }


        private static bool OnRestaurantCreated(RestaurantCreated arg)
        {
            Console.WriteLine(arg.RestaurantAgg.ToString());
            return true;
        }

        private static bool OnRestaurantNotFound(RestaurantNotFound arg)
        {
            Console.WriteLine(arg.Reason);
            return false;
        }


        private static bool OnRestaurantFound(RestaurantFound arg)
        {
            Console.WriteLine("Welcome to " + arg.RestaurantAgg.Restaurant.Name + "!");
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
