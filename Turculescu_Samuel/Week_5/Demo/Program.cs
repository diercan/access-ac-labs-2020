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
using static Domain.Domain.CreateMenuOp.CreateMenuResult;
using Microsoft.CodeAnalysis.VisualBasic.Syntax;
using System.Collections.Generic;
using Domain.Domain.GetRestaurantOp;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Domain.Domain.CreateClientOp;
using Infra.Free;
using Persistence;
using Persistence.Abstractions;
using Persistence.EfCore;
using Persistence.EfCore.Context;
using Persistence.EfCore.Operations;
using static Domain.Domain.CreateMenuItemOp.CreateMenuItemResult;
using static Domain.Domain.CreateEmployeeOp.CreateEmployeeResult;
using static Domain.Domain.GetRestaurantOp.GetRestaurantResult;
using static Domain.Domain.PlaceOrderOp.PlaceOrderResult;
using static Domain.Domain.ClientRoles.AddToCartOp.AddToCartResult;
using static Domain.Domain.GetMenusOp.GetMenusResult;
using Domain.Domain.GetMenusOp;

namespace Demo
{
    class Program
    {
        static async Task Main(string[] args)
        {
            var serviceCollection = new ServiceCollection();

            serviceCollection.AddOperations(typeof(RestaurantAgg).Assembly);
            serviceCollection.AddOperations(typeof(ClientAgg).Assembly);
            serviceCollection.AddOperations(typeof(EmployeeAgg).Assembly);
            serviceCollection.AddOperations(typeof(MenuAgg).Assembly);
            serviceCollection.AddOperations(typeof(MenuItemAgg).Assembly);
            serviceCollection.AddOperations(typeof(OrderAgg).Assembly);
            serviceCollection.AddOperations(typeof(OrderItemAgg).Assembly);

            serviceCollection.AddOperations(typeof(AddOrUpdateOp).Assembly);
            serviceCollection.AddTransient(typeof(IOp<,>), typeof(QueryOp<,>));

            serviceCollection.AddDbContext<OrderAndPayContext>(ServiceLifetime.Singleton);

            serviceCollection.AddOperations(typeof(OrderAndPayContext).Assembly);            

            var serviceProvider = serviceCollection.BuildServiceProvider();
            var interpreter = new LiveInterpreterAsync(serviceProvider);
            
            
           //Adding a Restaurant
                    var exprRestaurant =
                        from restaurantResult in RestaurantDomain.GetRestaurant("Restaurant_3")                        
                        let restaurant = (restaurantResult as RestaurantFound).Agg
                        from menuResult1 in RestaurantDomain.CreateMenuAndPersist("Pasta1", restaurant.Restaurant)
                        let menu1 = (menuResult1 as MenuCreated)?.Menu
                        from menuResult2 in RestaurantDomain.CreateMenuAndPersist("Pizza1", restaurant.Restaurant)
                        let menu2 = (menuResult2 as MenuCreated)?.Menu

                        from menuItemResult1 in RestaurantDomain.CreateMenuItemAndPersist(menu1.Menu, "Carbonara", "ingredients", "allergens", 100, 27.50m, true)
                        let menuItem1 = (menuItemResult1 as MenuItemCreated)?.MenuItem
                        from menuItemResult2 in RestaurantDomain.CreateMenuItemAndPersist(menu1.Menu, "Spaghetti", "ingredients", "allergens", 150, 25.50m, true)
                        let menuItem2 = (menuItemResult2 as MenuItemCreated)?.MenuItem
                        from menuItemResult3 in RestaurantDomain.CreateMenuItemAndPersist(menu1.Menu, "Macaroni", "ingredients", "allergens", 200, 20.50m, true)
                        let menuItem3 = (menuItemResult3 as MenuItemCreated)?.MenuItem
                        from menuItemResult4 in RestaurantDomain.CreateMenuItemAndPersist(menu2.Menu, "Pizza", "ingredients", "allergens", 100, 30.50m, true)
                        let menuItem4 = (menuItemResult4 as MenuItemCreated)?.MenuItem

                        /* from clientResult in RestaurantDomainEx.CreateClientAndPersist("Fifth", "Client", "fifthclient@gmail.com", "07xxxxxxxx", "xxxxxxxxxxxxxxxx", "fifth.client", "client05")
                         let client = (clientResult as ClientCreated)?.Client*/
                         from client in RestaurantDomainEx.GetClient("first.client")
                         from cartItemResult1 in RestaurantDomain.AddToCart("sessionClient05", menuItem4.MenuItem, 1, "special requests")
                         let cartItem1 = (cartItemResult1 as AddToCartSuccessful)?.CartItem
                         from cartItemResult2 in RestaurantDomain.AddToCart("sessionClient05", menuItem2.MenuItem, 2, "special requests")
                         let cartItem2 = (cartItemResult2 as AddToCartSuccessful)?.CartItem
                         from cartItemResult3 in RestaurantDomain.AddToCart("sessionClient05", menuItem3.MenuItem, 3, "special requests")
                         let cartItem3 = (cartItemResult3 as AddToCartSuccessful)?.CartItem

                         from orderResult in RestaurantDomain.PlaceOrderAndPersist(client.Client, restaurant.Restaurant, 140.00m, 5)
                         let order = (orderResult as OrderPlaced)?.Order

                         from orderItemResult1 in RestaurantDomain.CreateOrderItemAndPersist(cartItem1, order.Order)
                         from orderItemResult2 in RestaurantDomain.CreateOrderItemAndPersist(cartItem2, order.Order)
                         from orderItemResult3 in RestaurantDomain.CreateOrderItemAndPersist(cartItem3, order.Order)

                        select restaurant;
            var resultRestaurant = await interpreter.Interpret(exprRestaurant, Unit.Default);
            //var restaurant = await interpreter.Interpret(exprRestaurant, Unit.Default);
            //var finalResultRestaurant = restaurant.Match(OnRestaurantCreated, OnRestaurantNotCreated);
            //Assert.True(finalResultRestaurant);

            //Adding a Client
            /* var exprClient =
                 from clientResult in RestaurantDomainEx.CreateClientAndPersist("Third", "Client", "thirdclient@gmail.com", "07xxxxxxxx", "xxxxxxxxxxxxxxxx", "third.client", "client03")
                 let client = (clientResult as ClientCreated)?.Client
                 select clientResult;

             var resultClient = await interpreter.Interpret(exprClient, Unit.Default);


             //Adding an Employee
             var exprEmployee =
                   from employeeResult in RestaurantDomainEx.CreateEmployeeAndPersist("Employee", "01", "employee02@restaurant.com", "07xxxxxxxx", "Chef", "Chef01", "password", 4)
                   let employee = (employeeResult as EmployeeCreated)?.Employee
                   select employeeResult;

              var resultEmployee = await interpreter.Interpret(exprEmployee, Unit.Default);*/




            // Testing Queries
            /*var getRestaurantExpr =
                from restaurantResult in RestaurantDomainEx.GetRestaurant("Restaurant_4")
                select restaurantResult;

            var interpretedRestaurant = await interpreter.Interpret(getRestaurantExpr, Unit.Default);*/
            //var restaurantResponse = interpretedRestaurant.Match<bool>(OnRestaurantFound, OnRestaurantNotFound);

            /*var exprFindClient =
                from clientResult in RestaurantDomainEx.GetClient("second.client")
                select clientResult;
            var client = await interpreter.Interpret(exprFindClient, Unit.Default);*/

            /*var exprFindEmployee =
                from employeeResult in RestaurantDomainEx.GetEmployee(restaurant.Restaurant.Id, "waiter01")
                select employeeResult;
            var employee = await interpreter.Interpret(exprFindEmployee, Unit.Default);*/

            /*var exprFindMenus =
               from menusResult in RestaurantDomainEx.GetMenus(interpretedRestaurant.Restaurant)
               select menusResult;
            var menus = await interpreter.Interpret(exprFindMenus, Unit.Default);*/

            //var finalResultMenus = menus.Match(OnMenusFound, OnMenusNotFound);
            //Assert.True(finalResultMenus);

            //Console.WriteLine(restaurant.Restaurant.Name);
            //Console.WriteLine(client.Client.ClientId);
            //Console.WriteLine(employee.Employee.EmployeeId);

            /*foreach (Menu m in menus.Menus)
            {
                Console.WriteLine(m.Name);
            }*/


        }
        
    }
}
