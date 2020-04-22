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
using static Domain.Domain.AddMenuItemOp.AddMenuItemResult;
using Domain.Domain.AddMenuItemOp;
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

namespace Domain.Domain
{
    public static class RestaurantDomain
    {
        public static IO<ICreateRestaurantResult> CreateRestaurant(string name) =>
            NewIO<CreateRestaurantCmd, ICreateRestaurantResult>(new CreateRestaurantCmd(name));

        public static IO<CreateMenuResult.ICreateMenuResult> CreateMenu(Restaurant restaurant, string menuName,
            MenuType menuType)
            => NewIO<CreateMenuCmd, CreateMenuResult.ICreateMenuResult>(new CreateMenuCmd(restaurant, menuName, menuType));

        public static IO<ICreateMenuItemResult> CreateMenuItem(string name, double price)
            => NewIO<CreateMenuItemCmd, ICreateMenuItemResult>(new CreateMenuItemCmd(name, price));

        public static IO<IAddMenuItemResult> AddMenuItem(Menu menu, MenuItem menuItem)
            => NewIO<AddMenuItemCmd, IAddMenuItemResult>(new AddMenuItemCmd(menuItem, menu));

        public static IO<IAddMenuItemResult> CreateAndAddMenuItem(string name, double price, Menu menu)
            => from createMenuItemResult in CreateMenuItem(name, price)
               let createdMenuItem = (createMenuItemResult as MenuItemCreated)?.MenuItem
               from addMenuItemResult in AddMenuItem(menu, createdMenuItem)
               select addMenuItemResult;

        public static IO<ICreateClientResult> CreateClient(string uid)
           => NewIO<CreateClientCmd, ICreateClientResult>(new CreateClientCmd(uid));

        public static IO<IAddItemToCartResult> AddItemToCart(MenuItem menuItem, Client client)
           => NewIO<AddItemToCartCmd, IAddItemToCartResult>(new AddItemToCartCmd(menuItem, client));


        public static IO<ICreateOrderResult> CreateOder(Client client)
            => NewIO<CreateOrderCmd, ICreateOrderResult>(new CreateOrderCmd(client));

        public static IO<IPlaceOrderResult> PlaceOrder(Order order, Restaurant restaurant)
            => NewIO<PlaceOrderCmd, IPlaceOrderResult>(new PlaceOrderCmd(order, restaurant));

        public static IO<IPlaceOrderResult> CreateAndPlaceOrder(Client client, Restaurant restaurant)
            => from createOrderResult in CreateOder(client)
               let createdOrder = (createOrderResult as OrderCreated)?.Order
               from placeOrderResult in PlaceOrder(createdOrder, restaurant)
               select placeOrderResult;

        public static IO<IGetRestaurantResult> GetRestaurant(string name) =>
            NewIO<GetRestaurantCmd, IGetRestaurantResult>(new GetRestaurantCmd(name));

        public static IO<IGetMenuResult> GetMenu(Restaurant restaurant) =>
            NewIO<GetMenuCmd, IGetMenuResult>(new GetMenuCmd(restaurant));
    }
}
