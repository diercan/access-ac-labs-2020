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
using static Domain.Domain.CreateUserOp.CreateUserResult;
using Domain.Domain.CreateUserOp;
using static Domain.Domain.CreateMenuItemOp.CreateMenuItemResult;
using Domain.Domain.CreateMenuItemOp;
using static Domain.Domain.CreateEmployeeOp.CreateEmployeeResult;
using Domain.Domain.CreateEmployeeOp;
using System.Threading.Tasks;

namespace Domain.Domain
{
    public static class RestaurantDomain
    {
        public static IO<ICreateRestaurantResult> CreateRestaurant(string name) =>
            NewIO<CreateRestaurantCmd, ICreateRestaurantResult>(new CreateRestaurantCmd(name));

        public static IO<ICreateUserResult> CreateUser(string userName, string password, int age) =>
            NewIO<CreateUserCmd, ICreateUserResult>(new CreateUserCmd(userName, password, age));

        public static IO<ICreateEmployeeResult> CreateEmployee(string firstName, string lastName, int age, string address,
            decimal salary, Gender gender, Position position, Restaurant restaurant) =>
            NewIO<CreateEmployeeCmd, ICreateEmployeeResult>(new CreateEmployeeCmd(
                firstName, lastName, age, address, salary, gender, position, restaurant));

        public static IO<CreateMenuResult.ICreateMenuResult> CreateMenu(Restaurant restaurant, string menuName,
            MenuType menuType)
            => NewIO<CreateMenuCmd, CreateMenuResult.ICreateMenuResult>(new CreateMenuCmd(restaurant, menuName, menuType));

        public static IO<ICreateMenuItemResult> CreateMenuItem(string itemName, decimal price,
            List<string> ingredients, List<string> alergens, Menu menu)
            => NewIO<CreateMenuItemCmd, ICreateMenuItemResult>(new CreateMenuItemCmd(itemName, price, ingredients, alergens, menu));

    }
}
