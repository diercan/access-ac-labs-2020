using System;
using System.Collections.Generic;
using System.Text;
using Domain.Domain.CreateMenuOp;
using Domain.Domain.CreateRestauratOp;
using Domain.Models;
using Infra.Free;
using LanguageExt.ClassInstances;
using static IOExt;
using static Domain.Domain.CreateRestauratOp.CreateRestaurantResult;
using Domain.Domain.CreateMenuItemOp;
using Domain.Domain.GetOp;
using Domain.Domain.GetRestaurantOp;

namespace Domain.Domain
{
    public static class RestaurantDomain
    {
        public static IO<ICreateRestaurantResult> CreateRestaurant(List<Restaurant> restaurants ,string name) =>
            NewIO<CreateRestaurantCmd, ICreateRestaurantResult>(new CreateRestaurantCmd(restaurants, name));

        public static IO<CreateMenuResult.ICreateMenuResult> CreateMenu(Restaurant restaurant, string menuName,
            MenuType menuType)
            => NewIO<CreateMenuCmd, CreateMenuResult.ICreateMenuResult>(new CreateMenuCmd(restaurant, menuName, menuType));

        public static IO<CreateMenuItemResult.ICreateMenuItemResult> CreateMenuItem(Menu menu, string name, uint price) =>
            NewIO<CreateMenuItemCmd, CreateMenuItemResult.ICreateMenuItemResult>(new CreateMenuItemCmd(menu, name, price));

        /*public static IO<GetResult.IGetResult<T>> Get<T>(List<T> items, Predicate<T> expession) =>
            NewIO<GetCmd<T>, GetResult.IGetResult<T>>(new GetCmd<T>(items, expession));*/

        /*public static IO<GetResult.IGetResult<Restaurant>> GetRestaurant(List<Restaurant> items, Predicate<Restaurant> expession) =>
            NewIO<GetCmd<Restaurant>, GetResult.IGetResult<Restaurant>>(new GetCmd<Restaurant>(items, expession));*/
    }
}
