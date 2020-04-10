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

namespace Domain.Domain
{
    public static class RestaurantDomain
    {
        // Restaurant
        public static IO<ICreateRestaurantResult> CreateRestaurant(string name) =>
            NewIO<CreateRestaurantCmd, ICreateRestaurantResult>(new CreateRestaurantCmd(name));

        // Menu
        public static IO<CreateMenuResult.ICreateMenuResult> CreateMenu(Restaurant restaurant, string menuName,
            MenuType menuType)
            => NewIO<CreateMenuCmd, CreateMenuResult.ICreateMenuResult>(new CreateMenuCmd(restaurant, menuName, menuType));

        // Employee
        public static IO<ICreateEmployeeResult> CreateEmployee(String name, int age, String address, String telephone, float salary, JobRoles role, String iban, Restaurant restaurant)
            => NewIO<CreateEmployeeCmd, ICreateEmployeeResult>(new CreateEmployeeCmd(name, age, address, telephone, salary, role, iban, restaurant));

        public static IO<ICreateOrderResult> CreateOrder(int id, int tableNumber, List<MenuItem> items, String waiter, float price, Restaurant restaurant) =>
            NewIO<CreateOrderCmd, ICreateOrderResult>(new CreateOrderCmd(id, tableNumber, items, waiter, price, restaurant));
    }
}