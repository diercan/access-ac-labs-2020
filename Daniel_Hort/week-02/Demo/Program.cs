using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;
using Database.Abstractions;
using Domain.Domain;
using Domain.Models;
using Infrastructure.Free;
using LanguageExt;
using Microsoft.Extensions.DependencyInjection;
using Database.Context;
using Database.Entities;
using Database.Operations;
using Microsoft.EntityFrameworkCore;
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
            serviceCollection.AddOperations(typeof(AddOrUpdateOp).Assembly);
            serviceCollection.AddDbContext<OrderAndPayContext>(ServiceLifetime.Singleton);
            var serviceProvider = serviceCollection.BuildServiceProvider();

            var expr =
                from restaurantResult in RestaurantDomain.CreateRestaurant("McRonald")
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

            var interpreter = new LiveInterpreterAsync(serviceProvider);
            var expr1 = Database.Database.Get<RestaurantEntity>(a => true);
            var result = await interpreter.Interpret(expr1, Unit.Default);
            result.Match(a =>
            {
                a.Items.ForEach(b => Console.WriteLine(b.Name));
                return a;
            }, a =>
            {
                Console.WriteLine(a.Reason);
                return a;
            });
        }
    }
}
