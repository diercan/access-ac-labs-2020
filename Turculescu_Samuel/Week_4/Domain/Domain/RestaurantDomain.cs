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
using Domain.Domain.ChangeQuantityOp;
using Domain.Domain.GetRestaurantOp;
using Domain.Domain.GetMenusOp;
using Domain.Domain.CreateOrderItemOp;
using Domain.Domain.PlaceOrderOp;
using Domain.Domain.GetOrderStatusOp;
using Domain.Domain.PayOrderOp;
using Domain.Domain.GetEmployeeOp;
using Domain.Domain.ChangeMenuItemOp;
using Domain.Domain.GetOrdersOp;
using Domain.Domain.SetOrderStatusOp;
using Domain.Domain.CreatePaymentRequestOp;
using Domain.Domain.CheckOrderPaymentOp;
using Domain.Domain.CreateMenuOp;
using Domain.Domain.CreateMenuItemOp;
using Domain.Queries;
using Persistence;
using Persistence.EfCore;
using System.Data.SqlTypes;
using Domain.Domain.ClientRoles.AddToCartOp;

namespace Domain.Domain
{
    public static class RestaurantDomain
    {
        // CREATE RESTAURANT
        public static IO<ICreateRestaurantResult> CreateRestaurant(string name, string address) =>
            NewIO<CreateRestaurantCmd, ICreateRestaurantResult>(new CreateRestaurantCmd(name, address));

        // GET RESTAURANT
        public static IO<GetRestaurantResult.IGetRestaurantResult> GetRestaurant(Restaurant restaurant) =>
             NewIO<GetRestaurantCmd, GetRestaurantResult.IGetRestaurantResult>(new GetRestaurantCmd(restaurant));

        // CREATE CLIENT
        public static IO<ICreateClientResult> CreateClient(string firstName, string lastName, string email, string phone, string cardNumber, string clientId, string password) =>
            NewIO<CreateClientCmd, ICreateClientResult>(new CreateClientCmd(firstName, lastName, email, phone, cardNumber, clientId, password));

        // GET CLIENT
        public static IO<GetClientResult.IGetClientResult> GetClient(Client client) =>
            NewIO<GetClientCmd, GetClientResult.IGetClientResult>(new GetClientCmd(client));

        // CREATE EMPLOYEE
        public static IO<ICreateEmployeeResult> CreateEmployee(string firstName, string lastName, string email, string phone, string job, string employeeId, string password, int restaurantId) =>
            NewIO<CreateEmployeeCmd, ICreateEmployeeResult>(new CreateEmployeeCmd(firstName, lastName, email, phone, job, employeeId, password, restaurantId));

        // GET EMPLOYEE
        public static IO<GetEmployeeResult.IGetEmployeeResult> GetEmployee(Employee employee) =>
            NewIO<GetEmployeeCmd, GetEmployeeResult.IGetEmployeeResult>(new GetEmployeeCmd(employee));

        // CREATE MENU
        public static IO<CreateMenuResult.ICreateMenuResult> CreateMenu(string name, Restaurant restaurant) =>
            NewIO<CreateMenuCmd, CreateMenuResult.ICreateMenuResult>(new CreateMenuCmd(name, restaurant));

        // GET MENUS
        public static IO<GetMenusResult.IGetMenusResult> GetMenus(Restaurant restaurant) =>
            NewIO<GetMenusCmd, GetMenusResult.IGetMenusResult>(new GetMenusCmd(restaurant));

        // CREATE MENU ITEM
        public static IO<CreateMenuItemResult.ICreateMenuItemResult> CreateMenuItem(Menu menu, string name, string ingredients, string allergens, uint totalQuantity, double price, bool availability) =>
            NewIO<CreateMenuItemCmd, CreateMenuItemResult.ICreateMenuItemResult>(new CreateMenuItemCmd(menu, name, ingredients, allergens, totalQuantity, price, availability));

        // CHANGE MENU ITEM
        public static IO<ChangeMenuItemResult.IChangeMenuItemResult> ChangeMenuItem(MenuItem menuItem, MenuItem newMenuItem) =>
            NewIO<ChangeMenuItemCmd, ChangeMenuItemResult.IChangeMenuItemResult>(new ChangeMenuItemCmd(menuItem, newMenuItem));

        // ADD TO CART => 
        public static IO<AddToCartResult.IAddToCartResult> AddToCart(string sessionId, MenuItem menuItem, uint quantity, string specialRequests) =>
            NewIO<AddToCartCmd, AddToCartResult.IAddToCartResult>(new AddToCartCmd(sessionId, menuItem, quantity, specialRequests));

        // CREATE ORDER ITEM
        public static IO<CreateOrderItemResult.ICreateOrderItemResult> CreateOrderItem(CartItem cartItem, Order order) =>
            NewIO<CreateOrderItemCmd, CreateOrderItemResult.ICreateOrderItemResult>(new CreateOrderItemCmd(cartItem, order));

        // CHANGE QUANTITY
        public static IO<ChangeQuantityResult.IChangeQuantityResult> ChangeQuantity(string sessionId, OrderItem orderItem, uint newQuantity) =>
            NewIO<ChangeQuantityCmd, ChangeQuantityResult.IChangeQuantityResult>(new ChangeQuantityCmd(sessionId, orderItem, newQuantity));

        // PLACE ORDER => ORDER
        public static IO<PlaceOrderResult.IPlaceOrderResult> PlaceOrder(Client client, Restaurant restaurant, double totalPrice, uint tableNumber) =>
            NewIO<PlaceOrderCmd, PlaceOrderResult.IPlaceOrderResult>(new PlaceOrderCmd(client, restaurant, totalPrice, tableNumber));

        // GET ORDERS
        public static IO<GetOrdersResult.IGetOrdersResult> GetOrders(Restaurant restaurant) =>
            NewIO<GetOrdersCmd, GetOrdersResult.IGetOrdersResult>(new GetOrdersCmd(restaurant));

        // GET ORDER STATUS
        public static IO<GetOrderStatusResult.IGetOrderStatusResult> GetOrderStatus(Order order) =>
            NewIO<GetOrderStatusCmd, GetOrderStatusResult.IGetOrderStatusResult>(new GetOrderStatusCmd(order));

        // SET ORDER STATUS
        public static IO<SetOrderStatusResult.ISetOrderStatusResult> SetOrderStatus(Order order, string orderStatus, TimeSpan preparationTime) =>
            NewIO<SetOrderStatusCmd, SetOrderStatusResult.ISetOrderStatusResult>(new SetOrderStatusCmd(order, orderStatus, preparationTime));

        // CREATE PAYMENT REQUEST
        public static IO<CreatePaymentRequestResult.ICreatePaymentRequestResult> CreatePaymentRequest(Order order) =>
            NewIO<CreatePaymentRequestCmd, CreatePaymentRequestResult.ICreatePaymentRequestResult>(new CreatePaymentRequestCmd(order));

        // CHECK ORDER PAYMENT STATUS
        public static IO<CheckOrderPaymentResult.ICheckOrderPaymentResult> CheckOrderPaymentStatus(Order order) =>
            NewIO<CheckOrderPaymentCmd, CheckOrderPaymentResult.ICheckOrderPaymentResult>(new CheckOrderPaymentCmd(order));
       
        // PAY ORDER
        public static IO<PayOrderResult.IPayOrderResult> PayOrder(Client client, Order order, uint tip) =>
            NewIO<PayOrderCmd, PayOrderResult.IPayOrderResult>(new PayOrderCmd(client, order, tip));
    }
}
