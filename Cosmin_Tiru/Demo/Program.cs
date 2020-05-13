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
using Infra.Free;
using Infra.Persistence;
using Persistence;
using Persistence.Abstractions;
using Persistence.EfCore;
using Persistence.EfCore.Context;
using Persistence.EfCore.Operations;
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

            serviceCollection.AddOperations(typeof(RestaurantAgg).Assembly);
            serviceCollection.AddOperations(typeof(AddOrUpdateOp).Assembly);
            serviceCollection.AddTransient(typeof(IOp<,>), typeof(QueryOp<,>));

            //serviceCollection.AddDbContext<OrderAndPayContext>(ServiceLifetime.Singleton);

            var serviceProvider = serviceCollection.BuildServiceProvider();

            var expr =
                from r in RestaurantDomain.GetRestaurant("vinto")
                from restaurantResult in RestaurantDomain.CreateRestaurantAndPersist("vinto")
                let restaurant = (restaurantResult as RestaurantCreated)?.Restaurant
                from menuResult in RestaurantDomain.CreateMenu(restaurant, "paste", MenuType.Meat)
                let menu = (menuResult as MenuCreated)?.Menu
                from menuItemResult in RestaurantDomain.CreateAndAddMenuItem("carbonara", 100, menu)
                from menuItemResult1 in RestaurantDomain.CreateAndAddMenuItem("carbonara", 25, menu)
                from menuItemResult2 in RestaurantDomain.CreateAndAddMenuItem("conpesto", 20, menu)
                let menuItem2 = (menuItemResult2 as MenuItemAdded)?.MenuItem
                from clientResult in RestaurantDomain.CreateClient("gucdg34u6trgfh", "Anca")
                    //from orderResult in RestaurantDomain.CreateAndPlaceOrder(client, restaurant)
                select restaurantResult;

            var interpreter = new LiveInterpreterAsync(serviceProvider);

            var result = await interpreter.Interpret(expr, Unit.Default);
        }
    }
}
