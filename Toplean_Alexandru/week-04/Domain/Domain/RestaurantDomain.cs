using Domain.Domain.CreateRestauratOp;
using Infra.Free;
using static IOExt;
using static Domain.Domain.CreateRestauratOp.CreateRestaurantResult;
using Persistence;
using Domain.Models;
using Persistence.EfCore;
using Domain.Queries;
using static Domain.Domain.SelectRestaurantOp.SelectRestaurantResult;
using System;
using Domain.Domain.SelectRestaurantOp;

using Domain.Domain.CreateMenuOp;
using static Domain.Domain.CreateMenuOp.CreateMenuResult;
using System.Collections.Generic;

namespace Domain.Domain
{
    public static class RestaurantDomain
    {
        // Restaurant
        public static IO<ICreateRestaurantResult> CreateRestaurant(string name) =>
            NewIO<CreateRestaurantCmd, ICreateRestaurantResult>(new CreateRestaurantCmd(name));

        public static IO<CreateRestaurantResult.ICreateRestaurantResult> CreateAndPersist(string name) =>
            from restaurantCreated in RestaurantDomain.CreateRestaurant(name)
            let restaurantAgg = (restaurantCreated as RestaurantCreated)?.Restaurant
            from dbContext in Database.AddNewEntity(restaurantAgg.Restaurant)
            select restaurantCreated;

        public static IO<ISelectRestaurantResult> SelectRestaurant(Restaurant restaurant) =>
           NewIO<SelectRestaurantCmd, ISelectRestaurantResult>(new SelectRestaurantCmd(restaurant));

        public static IO<ISelectRestaurantResult> GetRestaurant(string name)
            => from restaurant in Database.Query<FindRestaurantQuery, Restaurant>(new FindRestaurantQuery(name))
               from getResult in RestaurantDomain.SelectRestaurant(restaurant)
               let agg = (getResult as SelectRestaurantResult.RestaurantSelected)?.Restaurant
               select getResult;

        public static IO<ICreateMenuResult> CreateMenu(int id, string name, String menuType, bool isVisible, String hours, Restaurant restaurant) =>
           NewIO<CreateMenuCmd, ICreateMenuResult>(new CreateMenuCmd(id, name, menuType, isVisible, hours, restaurant));

        public static IO<ICreateMenuResult> CreateAndPersistMenu(int id, string name, String menuType, bool isVisible, String hours, Restaurant restaurant) =>
            from menuCreated in RestaurantDomain.CreateMenu(id, name, menuType, isVisible, hours, restaurant)
            let menuAgg = (menuCreated as MenuCreated)?.Menu
            from dbContext in Database.AddNewEntity(menuAgg.Menu)
            select menuCreated;

        public static IO<ICollection<Menu>> GetAllMenus(int restaurantId) =>
            from getAllMenus in Database.Query<GetAllMenusQuery, ICollection<Menu>>(new GetAllMenusQuery(restaurantId))
            select getAllMenus;
    }
}