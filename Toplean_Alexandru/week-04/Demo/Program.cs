using System;
using System.Threading.Tasks;
using Domain.Domain;
using Domain.Domain.CreateRestauratOp;
using Domain.Domain.UpdateEntityOp;
using Domain.Entities;
using Domain.Models;
using Infra.Free;
using Infrastructure.Free;
using LanguageExt;
using Microsoft.Extensions.DependencyInjection;
using Persistence;
using Persistence.Abstractions;
using Persistence.EfCore;
using Persistence.EfCore.Context;
using Persistence.EfCore.Operations;
using static Domain.Domain.CreateMenuItemOp.CreateMenuItemResult;
using static Domain.Domain.CreateMenuOp.CreateMenuResult;

//using static Domain.Domain.CreateMenuOp.CreateMenuResult;

//using Persistence.EfCore.Context;
//using Persistence.EfCore.Operations;
using static Domain.Domain.CreateRestauratOp.CreateRestaurantResult;
using static Domain.Domain.SelectMenuOp.SelectMenuResult;
using static Domain.Domain.SelectRestaurantOp.SelectRestaurantResult;
using static Domain.Domain.UpdateEntityOp.UpdateEntityResult;

using static Domain.Domain.UpdateMenuOp.UpdateMenuResult;

namespace Demo
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var serviceCollection = new ServiceCollection();
            serviceCollection.AddOperations(typeof(RestaurantAgg).Assembly);
            serviceCollection.AddOperations(typeof(MenuAgg).Assembly);
            serviceCollection.AddOperations(typeof(AddOrUpdateEntityOp).Assembly);
            serviceCollection.AddTransient(typeof(IOp<,>), typeof(QueryOp<,>));

            serviceCollection.AddDbContext<OrderAndPayContext>(ServiceLifetime.Singleton);

            var serviceProvider = serviceCollection.BuildServiceProvider();

            var interpreter = new LiveInterpreterAsync(serviceProvider);

            //Selecting the restaurant
            var expr = from selectRestaurant in RestaurantDomain.GetRestaurant("McDonalds")
                       let restaurant = (selectRestaurant as RestaurantAgg)?.Restaurant
                       select selectRestaurant;

            var exprResult = await interpreter.Interpret(expr, Unit.Default);
            var finalExpr = await exprResult.MatchAsync(
                async (persisted) => // Restaurant Successfully selected
                {
                    // Populates the RestaurantAgg model with the data from two functions, using a LiveAsyncInterpreter.
                    // This function will firstly populate the ICollection<Menu> Menus by calling GetAllMenus, with all the menus from the database that have the restaurant's id
                    // After the ICollection<Menu> will be filled, for each entity it will call the GetAllMenuItems function to populate the menu
                    await RestaurantDomain.PopulateRestaurantModel(persisted.RestaurantAgg, RestaurantDomain.GetAllMenus, RestaurantDomain.GetAllMenuItems, interpreter);

                    //// Selects a menu with a specific name
                    var selectMenuExpr = from selectMenu in RestaurantDomain.GetMenu("Chicken", persisted.RestaurantAgg.Restaurant.Id)
                                         let menu = (selectMenu as MenuSelected)?.MenuAgg
                                         select selectMenu;

                    var selectMenuRes = await interpreter.Interpret(selectMenuExpr, Unit.Default);
                    var selectMenuResult = await selectMenuRes.MatchAsync(
                        async (selected) => // Menu was successfully selected
                        {
                            selected.MenuAgg.Menu.Hours = "8-13";

                            var updateRestaurantExprUnique = from updateRestauruant in RestaurantDomain.UpdateAndPersistEntity<IEntity>(selected.MenuAgg.Menu)
                                                             let updatem = (updateRestauruant as EntityUpdated<IEntity>)?.Entity
                                                             select updateRestauruant;
                            var updateRestaurantFin = await interpreter.Interpret(updateRestaurantExprUnique, Unit.Default);

                            var matchh = updateRestaurantFin.Match(
                                updated =>
                                {
                                    return updated;
                                },
                                notUpdated =>
                                {
                                    return notUpdated;
                                }
                                );
                            //var getAllMenuItems = from getAllMenus in RestaurantDomain.GetAllMenuItems(10)
                            //                      select getAllMenus;

                            //var getAllMenusResult = await interpreter.Interpret(getAllMenuItems, Unit.Default);

                            return selected;
                        },
                        async (notSelected) => // Menu not selected
                        {
                            return notSelected;
                        }

                        );

                    return persisted;
                },
                async (notPersisted) => // Restaurant not selected
                {
                    return notPersisted;
                }

                );

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
    }
}