﻿using System;
using System.Collections.Generic;
using System.Text;
using Domain.Domain.CreateMenuOp;
using Domain.Domain.CreateRestauratOp;
using Domain.Models;
using Infra.Free;
using LanguageExt.ClassInstances;
using static IOExt;
using static Domain.Domain.CreateRestauratOp.CreateRestaurantResult;
using System.Threading.Tasks;
using static Domain.Domain.CreateMenuItemOp.CreateMenuItemResult;
using Domain.Domain.CreateMenuItemOp;
using System.Security.Cryptography.X509Certificates;
using Domain.Domain.CreateClientOp;
using Domain.Domain.GetClientOp;
using Domain.Domain.GetMenuOp;
using Domain.Domain.GetRestaurantOp;

namespace Domain.Domain
{
    public static class RestaurantDomain
    {
        public static IO<ICreateRestaurantResult> CreateRestaurant(string name)
            => NewIO<CreateRestaurantCmd, ICreateRestaurantResult>(new CreateRestaurantCmd(name));

        public static IO<CreateMenuResult.ICreateMenuResult> CreateMenu(Restaurant restaurant, string menuName)
            => NewIO<CreateMenuCmd, CreateMenuResult.ICreateMenuResult>(new CreateMenuCmd(restaurant, menuName));
        public static IO<ICreateMenuItemResult> CreateMenuItem(Menu menu, string name,
            string ingredients, string allergens, uint price) 
            => NewIO<CreateMenuItemCmd, ICreateMenuItemResult>(new CreateMenuItemCmd(menu, name, ingredients, allergens, price));

        public static IO<GetRestaurantResult.IGetRestaurantResult> GetRestaurant(string name)
            => NewIO<GetRestaurantCmd, GetRestaurantResult.IGetRestaurantResult>(new GetRestaurantCmd(name));

        public static IO<CreateClientResult.ICreateClientResult> CreateClient(string name)
            => NewIO<CreateClientCmd, CreateClientResult.ICreateClientResult>(new CreateClientCmd(name));

        public static IO<GetMenuResult.IGetMenuResult> GetMenu(Restaurant restaurant, string name)
            => NewIO<GetMenuCmd, GetMenuResult.IGetMenuResult>(new GetMenuCmd(name, restaurant.Menus));
    }
}
