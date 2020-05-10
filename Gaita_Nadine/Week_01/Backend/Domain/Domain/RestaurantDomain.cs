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
using static Domain.Domain.CreateMenuOp.CreateMenuAndAddToRestaurantResult;
using static Domain.Domain.CreateIngredientOp.CreateIngredientResult;
using Domain.Domain.CreateIngredientOp;
using static Domain.Domain.CreateMenuItemOp.CreateMenuItemAndAddToMenuResult;
using Domain.Domain.CreateMenuItemOp;
using static Domain.Domain.GetRestaurantOp.GetRestaurantResult;
using Domain.Domain.GetRestaurantOp;
using static Domain.Domain.GetMenusOp.GetMenuResult;
using Domain.Domain.GetMenusOp;
using static Domain.Domain.CreateClientOp.CreateClientResult;
using Domain.Domain.CreateClientOp;
using Domain.Domain.GetClientOp;
using static Domain.Domain.GetClientOp.GetClientResult;
using static Domain.Domain.AddToCartOp.AddMenuItemToCartResult;
using Domain.Domain.AddToCartOp;
using static Domain.Domain.CreateOrderOp.CreateOrderResult;
using Domain.Domain.CreateOrderOp;
using static Domain.Domain.PlaceOrder.PlaceOrderResult;
using Domain.Domain.PlaceOrder;

namespace Domain.Domain
{
    public static class RestaurantDomain
    {

        public static IO<ICreateRestaurantResult> CreateRestaurant(string name) =>
            NewIO<CreateRestaurantCmd, ICreateRestaurantResult>(new CreateRestaurantCmd(name));

        public static IO<ICreateMenuResult> CreateMenuAndAddToRestaurant(Restaurant restaurant, string menuName,MenuType menuType) => 
            NewIO<CreateMenuAndAddToRestaurantCmd, ICreateMenuResult>(new CreateMenuAndAddToRestaurantCmd(restaurant, menuName, menuType));

        public static IO<ICreateMenuItemResult> CreateMenuItemAndAddToMenu(Menu menu, string name, double price, List<Ingredient> ingredients) =>
            NewIO<CreateMenuItemAndAddToMenuCmd, ICreateMenuItemResult>(new CreateMenuItemAndAddToMenuCmd(menu, name, price, ingredients));

        public static IO<ICreateIngredientResult> CreateIngredient(ushort noIngredients, List<string> ingredients) =>
            NewIO<CreateIngredientCmd, ICreateIngredientResult>(new CreateIngredientCmd(noIngredients, ingredients));

        public static IO<IGetRestaurantResult> GetRestaurant(string restaurantName) =>
            NewIO<GetRestaurantCmd, IGetRestaurantResult>(new GetRestaurantCmd(restaurantName));

        public static IO<IGetMenusResult> GetMenus(Restaurant restaurant) =>
            NewIO<GetMenusCmd, IGetMenusResult>(new GetMenusCmd(restaurant));

        public static IO<ICreateClientResult> CreateClient(string name, string email, string uid, string password) =>
            NewIO<CreateClientCmd, ICreateClientResult>(new CreateClientCmd(name, email, uid, password));
        public static IO<IGetClientResult> GetClient(string uid) =>
           NewIO<GetClientCmd, IGetClientResult>(new GetClientCmd(uid));

        public static IO<IAddMenuItemToCartResult> AddMenuItemToCart(Client client, MenuItem menuItem, ushort quantity) =>
            NewIO<AddMenuItemToCartCmd, IAddMenuItemToCartResult>(new AddMenuItemToCartCmd(client, menuItem, quantity));
        public static IO<ICreateOrderResult> CreateOrder(Restaurant restaurant, Client client) =>
           NewIO<CreateOrderCmd, ICreateOrderResult>(new CreateOrderCmd(restaurant, client));
        public static IO<IPlaceOrderResult> PlaceOrder(Order order) =>
           NewIO<PlaceOrderCmd, IPlaceOrderResult>(new PlaceOrderCmd(order));
    }
}
