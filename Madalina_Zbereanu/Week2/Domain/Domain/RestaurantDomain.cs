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
using Domain.Domain.CreateIngredientOp;

namespace Domain.Domain
{
    public static class RestaurantDomain
    {
        //Restaurant
        public static IO<ICreateRestaurantResult> CreateRestaurant(string name) =>
            NewIO<CreateRestaurantCmd, ICreateRestaurantResult>(new CreateRestaurantCmd(name));

        //Menu
        public static IO<CreateMenuResult.ICreateMenuResult> CreateMenu(Restaurant restaurant, string menuName, MenuType menuType) => 
            NewIO<CreateMenuCmd, CreateMenuResult.ICreateMenuResult>(new CreateMenuCmd(restaurant, menuName, menuType));

        //MenuItem
        public static IO<CreateMenuItemResult.ICreateMenuItemResult> CreateMenuItem(Menu menu, string menuItemName, List<Ingredient>menuItemIngredients,float menuItemPrice) =>
            NewIO<CreateMenuItemCmd, CreateMenuItemResult.ICreateMenuItemResult>(new CreateMenuItemCmd(menu, menuItemName, menuItemIngredients, menuItemPrice));

        //Ingredient
        public static IO<CreateIngredientResult.ICreateIngredientResult> CreateIngredient(string ingredientName) =>
            NewIO<CreateIngredientCmd, CreateIngredientResult.ICreateIngredientResult>(new CreateIngredientCmd(ingredientName));
    }
}
