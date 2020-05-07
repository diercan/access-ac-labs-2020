﻿using System;
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
using Infra.Free;
using Persistence;
using Persistence.Abstractions;
using Persistence.EfCore;
using Persistence.EfCore.Context;

using Persistence.EfCore.Operations;
using static Domain.Domain.EmployeeRoles.CreateMenuItemOp.CreateMenuItemResult;

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

            var expr =
                from r in RestaurantDomain.GetRestaurant("Restaurant 1")
                from restaurantResult in RestaurantDomain.CreateRestaurantAndPersist("Restaurant 1", "address")
                let restaurant = (restaurantResult as RestaurantCreated)?.Restaurant
                from menuResult in RestaurantDomain.CreateMenu(restaurant, "Pasta")
                let menu = (menuResult as MenuCreated)?.Menu
                from menuItemResult in RestaurantDomain.CreateMenuItem(menu, "Carbonara", 25, 100, "ingredients", "allergens", MenuItemState.Available)
                from menuItemResult1 in RestaurantDomain.CreateMenuItem(menu, "Spaghetti", 27, 150, "ingredients", "allergens", MenuItemState.Available)
                from menuItemResult2 in RestaurantDomain.CreateMenuItem(menu, "Macaroni", 21, 200, "ingredients", "allergens", MenuItemState.Available)
                let menuItem2 = (menuItemResult2 as MenuItemCreated)?.MenuItem
                from clientResult in RestaurantDomain.CreateClient("firstName", "lastName", "email@mail.com", "0764896338", "xxxxxxxxxxxxxxxx", 1)
                    //from orderResult in RestaurantDomain.CreateAndPlaceOrder(client, restaurant)
                select restaurantResult;

            var interpreter = new LiveInterpreterAsync(serviceProvider);

            var result = await interpreter.Interpret(expr, Unit.Default);

            /*
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
               from clientResult in RestaurantDomain.CreateClient("First", "Client", "firstclient@gmail.com", "07xxxxxxxx", "xxxx xxxx xxxx xxxx", 1)
               let client = (clientResult as ClientCreated)?.Client
               select clientResult;            

           var exprClient02 =
               from clientResult in RestaurantDomain.CreateClient("Second", "Client", "secondclient@gmail.com", "07xxxxxxxx", "xxxx xxxx xxxx xxxx", 2)
               let client = (clientResult as ClientCreated)?.Client
               select clientResult;

           var interpreter = new LiveInterpreterAsync(serviceProvider);

           var result = await interpreter.Interpret(expr, Unit.Default);
    */
        }
    }   
}
