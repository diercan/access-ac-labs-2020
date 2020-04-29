/*1a. GetRestaurant<GetRestaurantCmd, GetRestaurantResult>(string: name)
1b. GetClient<GetClientCmd, GetClientResult>(string: clientId)
2.  GetMenus<GetMenusCmd, GetMenusResult>(Restaurant: restaurant)
3.  AddToCart<AddToCartCmd, AddToCartResult>(string: sessionId, MenuItem: menuItem, uint: qty) :
							AddToCartSuccessful | AddToCartNotSuccessful | AddToCartInvalidRequest
4.  ChangeQty<ChangeQtyCmd, ChangeQtyResult>(string: sessionId, int: menuItemId, uint newQty)
5.  PlaceOrder<OrderCmd, OrderResult>(Cart cart, Restaurant: restaurant, Client: client, uint tip = 0)
6.  GetOrderStatus<GetOrderStatusCmd, GetOrderStatusResult>(Cart cart);
ASPNET.CORE -> RestaurantDomain -> Result -> Match -> HttpResponseMessage
HTTP Request ------------------------------------------HTTP Response(200)*/

/*
 *1a. GetReastaurant<,>(Func<Restaurant, bool> expresion)
 * 1b. GetClient<,>(Func<Client, bool> expresion)
 * #1. Get<Model,Cmd,Result>(Func<Model,bool> expresion) // should be a list not an object / interpretable
 * 
 * the other ones need the cart so we'll see it
 * 
 * Cart - list<(menuItem, uint)>, TotalPrice => Items.Sum(a => item1.price * item2), Client (or should I? Yeah probably)
 * So every Cart have a Client but a Client's Cart can be null. That if we do it separately
 * Or just include Cart into the Client but I'm not sure of that
 * Ma culc
*/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Domain;
using Domain.Domain.GetOp;
using Domain.Models;
using Infrastructure.Free;
using LanguageExt;
using Microsoft.Extensions.DependencyInjection;
using Database.Context;
using Microsoft.EntityFrameworkCore;
using Xunit;
using static Domain.Domain.CreateMenuOp.CreateMenuResult;
using static Domain.Domain.CreateRestauratOp.CreateRestaurantResult;
using static Domain.Domain.GetOp.GetResult;

namespace Demo
{
    class Program
    {
        static List<Restaurant> Restaurants { get; set; }
        static List<Client> Clients { get; set; }
        static List<Order> Orders { get; set; }

        static async Task Main(string[] args)
        {
            Restaurants = new List<Restaurant>();
            Clients = new List<Client>();

            var serviceCollection = new ServiceCollection();
            serviceCollection.AddOperations(typeof(Restaurant).Assembly);
            serviceCollection.AddDbContext<OrderAndPayContext>();
            var serviceProvider = serviceCollection.BuildServiceProvider();

            var expr =
                from restaurantResult in RestaurantDomain.CreateRestaurant(Restaurants, "McRonald")
                let restaurant = (restaurantResult as RestaurantCreated)?.Restaurant
                from menuRes1 in RestaurantDomain.CreateMenu(restaurant, "Burgers", MenuType.Meat)
                let menu1 = (menuRes1 as MenuCreated)?.Menu
                from menuItemRes1 in RestaurantDomain.CreateMenuItem(menu1, "Tasty", 13)
                from menuItemRes2 in RestaurantDomain.CreateMenuItem(menu1, "Cheese King", 5)
                from menuRes2 in RestaurantDomain.CreateMenu(restaurant, "Drinks", MenuType.Beverages)
                let menu2 = (menuRes2 as MenuCreated)?.Menu
                from menuItemRes3 in RestaurantDomain.CreateMenuItem(menu2, "Pepsi", 7)
                from menuItemRes4 in RestaurantDomain.CreateMenuItem(menu2, "Cola", 7)
                select restaurantResult;

            var res2 = RestaurantDomain.CreateRestaurant(Restaurants, "KFC");

            var interpreter = new LiveInterpreterAsync(serviceProvider);
            var result = await interpreter.Interpret(expr, Unit.Default);
            await interpreter.Interpret(res2, Unit.Default);

            var res = ((await interpreter.Interpret(RestaurantDomain
                .Get(Restaurants, a => a.Menus.Count > 0), Unit.Default))
                .Match(OnFound, OnNotFound) as List<Restaurant>).FirstOrDefault();
            var menu = ((await interpreter.Interpret(RestaurantDomain
                .Get(res.Menus, a => a.MenuType == MenuType.Beverages), Unit.Default))
                .Match(OnFound, OnNotFound) as List<Menu>).FirstOrDefault();

            Console.WriteLine($"Meniul gasit: {menu.Name}");

            int op = 0;

            do
            {
                Console.WriteLine("\n1. Display Menus");
                Console.WriteLine("0. Exit");
                Console.Write("Option: ");

                op = int.Parse(Console.ReadLine());

                switch (op)
                {
                    case 1:
                        Console.WriteLine("{0}'s Menus", res.Name);
                        res.Menus.ForEach(a =>
                        {
                            Console.WriteLine("\t~{0} [{1}]~", a.Name, a.MenuType);
                            a.Items.ForEach(b => Console.WriteLine("\t\t{0} / {1}", b.Name, b.Price));
                        });
                        break;
                    case 2:
                    default:
                        Console.WriteLine("Not an option");
                        break;
                }

            } while (op != 0);
        }

        private static object OnNotFound<T>(NotFound<T> arg)
        {
            return arg.Reason;
        }

        private static object OnFound<T>(Found<T> arg)
        {
            return arg.Items;
        }
    }
}
