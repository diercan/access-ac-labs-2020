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

namespace Domain.Domain
{
    public static class RestaurantDomain
    {
        // RESTAURANT
        public static IO<ICreateRestaurantResult> CreateRestaurant(string name, string address) =>
            NewIO<CreateRestaurantCmd, ICreateRestaurantResult>(new CreateRestaurantCmd(name, address));

        public static IO<CreateRestaurantResult.ICreateRestaurantResult> CreateRestaurantAndPersist(string name, string address)
            => from restaurantCreated in RestaurantDomain.CreateRestaurant(name, address)
               let agg = (restaurantCreated as CreateRestaurantResult.RestaurantCreated)?.Restaurant
               from db in Database.AddOrUpdate(agg.Restaurant)
               select restaurantCreated;

        // EMPLOYEE
        public static IO<ICreateEmployeeResult> CreateEmployee(string firstName, string lastName, string email, string phone, string employeeId, RestaurantAgg restaurant) =>
            NewIO<CreateEmployeeCmd, ICreateEmployeeResult>(new CreateEmployeeCmd(firstName, lastName, email, phone, employeeId, restaurant));

        public static IO<GetEmployeeResult.IGetEmployeeResult> GetEmployee(RestaurantAgg restaurant, string employeeId) =>
            NewIO<GetEmployeeCmd, GetEmployeeResult.IGetEmployeeResult>(new GetEmployeeCmd(restaurant, employeeId));

        public static IO<CreateMenuResult.ICreateMenuResult> CreateMenu(RestaurantAgg restaurant, string menuName) =>
            NewIO<CreateMenuCmd, CreateMenuResult.ICreateMenuResult>(new CreateMenuCmd(restaurant, menuName));

        public static IO<CreateMenuItemResult.ICreateMenuItemResult> CreateMenuItem(Menu menu, string name, double price, uint quantity, string ingredients, string allergens, MenuItemState menuItemState) =>
            NewIO<CreateMenuItemCmd, CreateMenuItemResult.ICreateMenuItemResult>(new CreateMenuItemCmd(menu, name, price, quantity, ingredients, allergens, menuItemState));

        public static IO<ChangeMenuItemResult.IChangeMenuItemResult> ChangeMenuItem(Menu menu, int menuItemId, MenuItem newMenuItem) =>
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
        public static IO<ICreateClientResult> CreateClient(string firstName, string lastName, string email, string phone, string cardNumber, int clientId) =>
            NewIO<CreateClientCmd, ICreateClientResult>(new CreateClientCmd(firstName, lastName, email, phone, cardNumber, clientId));

        public static IO<GetClientResult.IGetClientResult> GetClient(string clientId) =>
            NewIO<GetClientCmd, GetClientResult.IGetClientResult>(new GetClientCmd(clientId));

        public static IO<GetRestaurantResult.IGetRestaurantResult> GetRestaurant(Restaurant restaurant) =>
             NewIO<GetRestaurantCmd, GetRestaurantResult.IGetRestaurantResult>(new GetRestaurantCmd(restaurant));

        public static IO<RestaurantAgg> GetRestaurant(string name)
           => from restaurant in Database.Query<FindRestaurantQuery, Restaurant>(new FindRestaurantQuery(name))
              from getResult in RestaurantDomain.GetRestaurant(restaurant)
              let agg = (getResult as GetRestaurantResult.RestaurantFound)?.Agg
              select agg;

        public static IO<GetMenusResult.IGetMenusResult> GetMenu(RestaurantAgg restaurant) =>
            NewIO<GetMenusCmd, GetMenusResult.IGetMenusResult>(new GetMenusCmd(restaurant));

        public static IO<AddToCartResult.IAddToCartResult> AddToCart(string sessionId, MenuItem menuItem, uint quantity, string specialRequests) =>
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
