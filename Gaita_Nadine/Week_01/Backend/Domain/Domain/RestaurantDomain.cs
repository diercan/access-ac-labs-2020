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
using static Domain.Domain.CreateMenuOp.CreateMenuResult;
using static Domain.Domain.CreateIngredientOp.CreateIngredientResult;
using Domain.Domain.CreateIngredientOp;
using static Domain.Domain.CreateMenuItemOp.CreateMenuItemResult;
using Domain.Domain.CreateMenuItemOp;
using static Domain.Domain.GetRestaurantOp.GetRestaurantResult;
using Domain.Domain.GetRestaurantOp;
using static Domain.Domain.GetMenusOp.GetMenuResult;
using Domain.Domain.GetMenusOp;

namespace Domain.Domain
{
    public static class RestaurantDomain
    {

        public static IO<ICreateRestaurantResult> CreateRestaurant(string name) =>
            NewIO<CreateRestaurantCmd, ICreateRestaurantResult>(new CreateRestaurantCmd(name));

        public static IO<ICreateMenuResult> CreateMenu(Restaurant restaurant, string menuName,MenuType menuType) => 
            NewIO<CreateMenuCmd, ICreateMenuResult>(new CreateMenuCmd(restaurant, menuName, menuType));

        public static IO<ICreateMenuItemResult> CreateMenuItem(Menu menu, string name, double price, List<Ingredient> ingredients) =>
            NewIO<CreateMenuItemCmd, ICreateMenuItemResult>(new CreateMenuItemCmd(menu, name, price, ingredients));

        public static IO<ICreateIngredientResult> CreateIngredient(ushort noIngredients, List<string> ingredients) =>
            NewIO<CreateIngredientCmd, ICreateIngredientResult>(new CreateIngredientCmd(noIngredients, ingredients));

        public static IO<IGetRestaurantResult> GetRestaurant(string restaurantName) =>
            NewIO<GetRestaurantCmd, IGetRestaurantResult>(new GetRestaurantCmd(restaurantName));

        public static IO<IGetMenusResult> GetMenus(Restaurant restaurant) =>
            NewIO<GetMenusCmd, IGetMenusResult>(new GetMenusCmd(restaurant));
    }
}
