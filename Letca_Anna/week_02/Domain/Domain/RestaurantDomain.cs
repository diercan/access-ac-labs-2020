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
using static Domain.Domain.CreateMenuItemOp.CreateMenuItemResult;
using Domain.Domain.CreateMenuItemOp;
using static Domain.Domain.CreateClientOp.CreateClientResult;
using Domain.Domain.CreateClientOp;
using static Domain.Domain.AddItemToCartOp.AddItemToCartResult;
using Domain.Domain.AddItemToCartOp;
using static Domain.Domain.PlaceOrderOp.PlaceOrderResult;
using Domain.Domain.PlaceOrderOp;
using Domain.Domain.CreateOrderOp;
using static Domain.Domain.CreateOrderOp.CreateOrderResult;
using static Domain.Domain.GetRestaurantOp.GetRestaurantResult;
using Domain.Domain.GetRestaurantOp;
using static Domain.Domain.GetMenuOp.GetMenuResult;
using Domain.Domain.GetMenuOp;
using static Domain.Domain.GetClientOp.GetClientResult;
using Domain.Domain.GetClientOp;
using static Domain.Domain.GetMenuItemResult.MenuItemResult;
using Domain.Domain.GetMenuItemOp;
using Persistence;
using Domain.Queries;
using Persistence.EfCore;
using static Domain.Domain.CreateMenuOp.CreateMenuResult;
using static Persistence.Abstractions.AddOrUpdateResult;

namespace Domain.Domain
{
    public static class RestaurantDomain
    {
        public static IO<ICreateRestaurantResult> CreateRestaurant(string name) =>
            NewIO<CreateRestaurantCmd, ICreateRestaurantResult>(new CreateRestaurantCmd(name));

        public static IO<CreateRestaurantResult.ICreateRestaurantResult> CreateRestaurantAndPersist(string name)
            => from restaurantCreated in RestaurantDomain.CreateRestaurant(name)
               let agg = (restaurantCreated as CreateRestaurantResult.RestaurantCreated)?.RestaurantAgg
               from db in Database.AddOrUpdate(agg.Restaurant)
               select restaurantCreated;

        public static IO<IGetRestaurantResult> GetRestaurant(string name)
            => from restaurant in Database.Query<FindRestaurantQuery, Restaurant>(new FindRestaurantQuery(name))
               from getResult in RestaurantDomain.GetRestaurant(restaurant)
               let agg = (getResult as GetRestaurantResult.RestaurantFound)?.RestaurantAgg
               select getResult;

        public static IO<IGetRestaurantResult> GetRestaurant(Restaurant restaurant) =>
             NewIO<GetRestaurantCmd, IGetRestaurantResult>(new GetRestaurantCmd(restaurant));

        public static IO<IAddOrUpdateResult> CreateMenuAndPersist(Menus menu, int restaurantId)
            => from menuCreated in CreateMenu(menu, restaurantId)
               let menuResult = (menuCreated as MenuCreated)?.Menu
               from db in Database.AddOrUpdate(menuResult)
               select db;

        public static IO<CreateMenuResult.ICreateMenuResult> CreateMenu(Menus menu, int restaurantId)
           => NewIO<CreateMenuCmd, CreateMenuResult.ICreateMenuResult>(new CreateMenuCmd(menu, restaurantId));

        public static IO<IGetMenuResult> GetMenu(Restaurant restaurant) =>
            NewIO<GetMenuCmd, IGetMenuResult>(new GetMenuCmd(restaurant));



        public static IO<ICreateMenuItemResult> CreateMenuItemAndPersist(string name, decimal price, Menus menu)
            => from createMenuItemResult in CreateMenuItem(name, price, menu)
               from db in Database.AddOrUpdate(menu)
               select createMenuItemResult;

        public static IO<ICreateMenuItemResult> CreateMenuItem(string name, decimal price, Menus menu)
            => NewIO<CreateMenuItemCmd, ICreateMenuItemResult>(new CreateMenuItemCmd(name, price, menu));

        public static IO<IGetMenuItemResult> GetMenuItem(string name, Menu menu) =>
            NewIO<GetMenuItemCmd, IGetMenuItemResult>(new GetMenuItemCmd(name, menu));

        public static IO<IAddItemToCartResult> AddItemToCart(MenuItem menuItem, Client client)
           => NewIO<AddItemToCartCmd, IAddItemToCartResult>(new AddItemToCartCmd(menuItem, client));

        public static IO<IAddItemToCartResult> GetItemAndAddToCart(string name, Menu menu, Client client)
            => from getItemResult in GetMenuItem(name, menu)
               let item = (getItemResult as MenuItemFound)?.MenuItem
               from addToCartResult in AddItemToCart(item, client)
               select addToCartResult;



        public static IO<ICreateClientResult> CreateClient(string uid, string name)
           => NewIO<CreateClientCmd, ICreateClientResult>(new CreateClientCmd(uid, name));

        public static IO<IGetClientResult> GetClient(string uid) =>
            NewIO<GetClientCmd, IGetClientResult>(new GetClientCmd(uid));



        public static IO<ICreateOrderResult> CreateOder(Client client)
            => NewIO<CreateOrderCmd, ICreateOrderResult>(new CreateOrderCmd(client));

        public static IO<IPlaceOrderResult> PlaceOrder(Order order, RestaurantAgg restaurant)
            => NewIO<PlaceOrderCmd, IPlaceOrderResult>(new PlaceOrderCmd(order, restaurant));

        public static IO<IPlaceOrderResult> CreateAndPlaceOrder(Client client, RestaurantAgg restaurant)
            => from createOrderResult in CreateOder(client)
               let createdOrder = (createOrderResult as OrderCreated)?.Order
               from placeOrderResult in PlaceOrder(createdOrder, restaurant)
               select placeOrderResult;
    }
}
