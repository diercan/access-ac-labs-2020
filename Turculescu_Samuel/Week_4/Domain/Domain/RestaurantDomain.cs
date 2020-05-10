using System;
using System.Collections.Generic;
using System.Text;
using LanguageExt.ClassInstances;
using LanguageExt;
using static IOExt;
using Infra.Free;
using Domain.Models;
using Domain.Domain.CreateRestaurantOp;
using Domain.Domain.CreateClientOp;
using Domain.Domain.CreateEmployeeOp;
using static Domain.Domain.CreateRestaurantOp.CreateRestaurantResult;
using static Domain.Domain.CreateClientOp.CreateClientResult;
using Domain.Domain.GetClientOp;
using static Domain.Domain.CreateEmployeeOp.CreateEmployeeResult;
using Domain.Domain.ClientRoles.ChangeQuantityOp;
using Domain.Domain.ClientRoles.GetRestaurantOp;
using Domain.Domain.ClientRoles.GetMenusOp;
using Domain.Domain.ClientRoles.AddToCartOp;
using Domain.Domain.ClientRoles.PlaceOrderOp;
using Domain.Domain.ClientRoles.GetOrderStatusOp;
using Domain.Domain.ClientRoles.PayOrderOp;
using Domain.Domain.GetEmployeeOp;
using Domain.Domain.EmployeeRoles.ChangeMenuItemOp;
using Domain.Domain.EmployeeRoles.GetOrdersOp;
using Domain.Domain.EmployeeRoles.SetOrderStatusOp;
using Domain.Domain.EmployeeRoles.CreatePaymentRequestOp;
using Domain.Domain.EmployeeRoles.CheckOrderPaymentOp;
using Domain.Domain.EmployeeRoles.CreateMenuOp;
using Domain.Domain.EmployeeRoles.CreateMenuItemOp;
using Domain.Queries;
using Persistence;
using Persistence.EfCore;
using System.Data.SqlTypes;

namespace Domain.Domain
{
    public static class RestaurantDomain
    {
        // RESTAURANT
        public static IO<ICreateRestaurantResult> CreateRestaurant(string name, string address) =>
            NewIO<CreateRestaurantCmd, ICreateRestaurantResult>(new CreateRestaurantCmd(name, address));

        // EMPLOYEE
        public static IO<ICreateEmployeeResult> CreateEmployee(string firstName, string lastName, string email, string phone, string job, string username, string password, int restaurantId) =>
            NewIO<CreateEmployeeCmd, ICreateEmployeeResult>(new CreateEmployeeCmd(firstName, lastName, email, phone, job, username, password, restaurantId));

        public static IO<GetEmployeeResult.IGetEmployeeResult> GetEmployee(Employee employee) =>
            NewIO<GetEmployeeCmd, GetEmployeeResult.IGetEmployeeResult>(new GetEmployeeCmd(employee));

        public static IO<CreateMenuResult.ICreateMenuResult> CreateMenu(string name, int restaurantId) =>
            NewIO<CreateMenuCmd, CreateMenuResult.ICreateMenuResult>(new CreateMenuCmd(name, restaurantId));

        public static IO<CreateMenuItemResult.ICreateMenuItemResult> CreateMenuItem(string name, string ingredients, string allergens, uint totalQuantity, double price, bool availability, int menuId) =>
            NewIO<CreateMenuItemCmd, CreateMenuItemResult.ICreateMenuItemResult>(new CreateMenuItemCmd(name, ingredients, allergens, totalQuantity, price, availability, menuId));

        public static IO<ChangeMenuItemResult.IChangeMenuItemResult> ChangeMenuItem(MenuAgg menu, int menuItemId, MenuItemAgg newMenuItem) =>
            NewIO<ChangeMenuItemCmd, ChangeMenuItemResult.IChangeMenuItemResult>(new ChangeMenuItemCmd(menu, menuItemId, newMenuItem));

        public static IO<GetOrdersResult.IGetOrdersResult> GetOrders(RestaurantAgg restaurant) =>
            NewIO<GetOrdersCmd, GetOrdersResult.IGetOrdersResult>(new GetOrdersCmd(restaurant));

        public static IO<SetOrderStatusResult.ISetOrderStatusResult> SetOrderStatus(Order order, OrderStatus orderStatus, uint preparationTimeInMinutes) =>
            NewIO<SetOrderStatusCmd, SetOrderStatusResult.ISetOrderStatusResult>(new SetOrderStatusCmd(order, orderStatus, preparationTimeInMinutes));

        public static IO<CreatePaymentRequestResult.ICreatePaymentRequestResult> CreatePaymentRequest(Order order, PaymentStatus newPaymentStatus) =>
            NewIO<CreatePaymentRequestCmd, CreatePaymentRequestResult.ICreatePaymentRequestResult>(new CreatePaymentRequestCmd(order, newPaymentStatus));

        public static IO<CheckOrderPaymentResult.ICheckOrderPaymentResult> CheckOrderPaymentStatus(Order order) =>
            NewIO<CheckOrderPaymentCmd, CheckOrderPaymentResult.ICheckOrderPaymentResult>(new CheckOrderPaymentCmd(order));

        // CLIENT
        public static IO<ICreateClientResult> CreateClient(string firstName, string lastName, string email, string phone, string cardNumber, string username, string password) =>
            NewIO<CreateClientCmd, ICreateClientResult>(new CreateClientCmd(firstName, lastName, email, phone, cardNumber, username, password));

        public static IO<GetClientResult.IGetClientResult> GetClient(Client client) =>
            NewIO<GetClientCmd, GetClientResult.IGetClientResult>(new GetClientCmd(client));

        public static IO<GetRestaurantResult.IGetRestaurantResult> GetRestaurant(Restaurant restaurant) =>
             NewIO<GetRestaurantCmd, GetRestaurantResult.IGetRestaurantResult>(new GetRestaurantCmd(restaurant));

        public static IO<GetMenusResult.IGetMenusResult> GetMenu(RestaurantAgg restaurant) =>
            NewIO<GetMenusCmd, GetMenusResult.IGetMenusResult>(new GetMenusCmd(restaurant));

        public static IO<AddToCartResult.IAddToCartResult> AddToCart(string sessionId, MenuItemAgg menuItem, uint quantity, string specialRequests) =>
            NewIO<AddToCartCmd, AddToCartResult.IAddToCartResult>(new AddToCartCmd(sessionId, menuItem, quantity, specialRequests));

        public static IO<ChangeQuantityResult.IChangeQuantityResult> ChangeQuantity(string sessionId, CartItem cartItem, uint newQuantity) =>
            NewIO<ChangeQuantityCmd, ChangeQuantityResult.IChangeQuantityResult>(new ChangeQuantityCmd(sessionId, cartItem, newQuantity));

        public static IO<PlaceOrderResult.IPlaceOrderResult> PlaceOrder(Client client, RestaurantAgg restaurant, Cart cart, uint tableNumber) =>
            NewIO<PlaceOrderCmd, PlaceOrderResult.IPlaceOrderResult>(new PlaceOrderCmd(client, restaurant, cart, tableNumber));

        public static IO<GetOrderStatusResult.IGetOrderStatusResult> GetOrderStatus(Order order) =>
            NewIO<GetOrderStatusCmd, GetOrderStatusResult.IGetOrderStatusResult>(new GetOrderStatusCmd(order));

        public static IO<PayOrderResult.IPayOrderResult> PayOrder(ClientAgg client, Order order, uint tip) =>
            NewIO<PayOrderCmd, PayOrderResult.IPayOrderResult>(new PayOrderCmd(client, order, tip));
    }
}
