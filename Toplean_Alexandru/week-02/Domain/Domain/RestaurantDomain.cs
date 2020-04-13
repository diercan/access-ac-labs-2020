using System;
using System.Collections.Generic;
using System.Text;
using Domain.Domain.CreateMenuOp;
using Domain.Domain.CreateRestauratOp;
using Domain.Domain.CreateEmployeeOp;
using Domain.Models;
using Infra.Free;
using LanguageExt.ClassInstances;
using static IOExt;
using static Domain.Domain.CreateRestauratOp.CreateRestaurantResult;
using static Domain.Domain.CreateEmployeeOp.CreateEmployeeResult;
using static Domain.Models.Employee;
using static Domain.Domain.CreateOrderOp.CreateOrderResult;
using Domain.Domain.CreateOrderOp;
using static Domain.Domain.SelectRestaurantOp.SelectRestaurantResult;
using Domain.Domain.SelectRestaurantOp;
using static Domain.Domain.DeleteRestaurantOp.DeleteRestaurantResult;
using Domain.Domain.DeleteRestaurantOp;
using static Domain.Domain.CreateMenuItem.CreateMenuItemResult;
using Domain.Domain.CreateMenuItem;

namespace Domain.Domain
{
    public static class RestaurantDomain
    {
        // Restaurant
        public static IO<ICreateRestaurantResult> CreateRestaurant(string name) =>
            NewIO<CreateRestaurantCmd, ICreateRestaurantResult>(new CreateRestaurantCmd(name));

        // Menu
        public static IO<CreateMenuResult.ICreateMenuResult> CreateMenu(Restaurant restaurant, string menuName, MenuType menuType)
            => NewIO<CreateMenuCmd, CreateMenuResult.ICreateMenuResult>(new CreateMenuCmd(restaurant, menuName, menuType));

        // Employee
        public static IO<ICreateEmployeeResult> CreateEmployee(String name, int age, String address, String telephone, float salary, JobRoles role, String iban, Restaurant restaurant)
            => NewIO<CreateEmployeeCmd, ICreateEmployeeResult>(new CreateEmployeeCmd(name, age, address, telephone, salary, role, iban, restaurant));

        public static IO<ICreateOrderResult> CreateOrder(int id, int tableNumber, List<MenuItem> items, String waiter, float price, Restaurant restaurant) =>
            NewIO<CreateOrderCmd, ICreateOrderResult>(new CreateOrderCmd(id, tableNumber, items, waiter, price, restaurant));

        public static IO<ISelectRestaurantResult> SelectRestaurant(String name) =>
            NewIO<SelectRestaurantCmd, ISelectRestaurantResult>(new SelectRestaurantCmd(name));

        public static IO<IDeleteRestaurantResult> DeleteRestaurant(String name) =>
            NewIO<DeleteRestaurantCmd, IDeleteRestaurantResult>(new DeleteRestaurantCmd(name));

        public static IO<ICreateMenuItemResult> CreateMenuItem(String name, float price, List<String> alergens, List<String> ingredients, String imageData, Menu menu) =>
            NewIO<CreateMenuItemCmd, ICreateMenuItemResult>(new CreateMenuItemCmd(name, price, alergens, ingredients, imageData, menu));
    }
}