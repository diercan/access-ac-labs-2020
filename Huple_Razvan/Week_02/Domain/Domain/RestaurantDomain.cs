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
using Domain.Domain.GetMenusOp;
using Domain.Domain.GetRestaurantOp;
using Domain.Domain.GetClientOp;
using Domain.Domain.AddToCartOp;
using Domain.Domain.ChangeQtyOp;
using Domain.Domain.GetMenuItemOp;

namespace Domain.Domain
{
    public static class RestaurantDomain
    {
        public static IO<ICreateRestaurantResult> CreateRestaurant(string name) =>
            NewIO<CreateRestaurantCmd, ICreateRestaurantResult>(new CreateRestaurantCmd(name));

        public static IO<CreateMenuResult.ICreateMenuResult> CreateMenu(Restaurant restaurant, string menuName,
            MenuType menuType)
            => NewIO<CreateMenuCmd, CreateMenuResult.ICreateMenuResult>(new CreateMenuCmd(restaurant, menuName, menuType));

        public static IO<CreateMenuItemResult.ICreateMenuItemResult> CreateMenuItem(Menu menu, string title,
            uint price, List<string> ingredients)
            => NewIO<CreateMenuItemCmd, CreateMenuItemResult.ICreateMenuItemResult>(new CreateMenuItemCmd(menu, title, price, ingredients));

        public static IO<GetMenuItemResult.IGetMenuItemResult> GetMenuItem(Menu menu, string title)
            => NewIO<GetMenuItemCmd, GetMenuItemResult.IGetMenuItemResult>(new GetMenuItemCmd(menu, title));
        public static IO<GetMenusResult.IGetMenusResult> GetMenus(Restaurant restaurant,string name)
            => NewIO<GetMenusCmd, GetMenusResult.IGetMenusResult>(new GetMenusCmd(restaurant, name));

        public static IO<GetRestaurantResult.IGetRestaurantResult> GetRestaurant(string name)
            => NewIO<GetRestaurantCmd, GetRestaurantResult.IGetRestaurantResult>(new GetRestaurantCmd(name));
        
        public static IO<GetClientResult.IGetClientResult> GetClient(string name)
            => NewIO<GetClientCmd, GetClientResult.IGetClientResult>(new GetClientCmd(name));

        public static IO<AddToCartResult.IAddToCartResult> AddToCart(string sessionId, Client client, MenuItem menuItem, uint qty)
            => NewIO<AddToCartCmd, AddToCartResult.IAddToCartResult>(new AddToCartCmd(sessionId,client,menuItem,qty));

        public static IO<ChangeQtyResult.IChangeQtyResult> ChangeQty(string sessionId, Client client, MenuItem menuItem, uint qty)
            => NewIO<ChangeQtyCmd, ChangeQtyResult.IChangeQtyResult>(new ChangeQtyCmd(sessionId,client,menuItem,qty));

    }
}
