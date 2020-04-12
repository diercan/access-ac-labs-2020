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
    }
}
