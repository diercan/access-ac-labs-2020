using System;
using System.Collections.Generic;
using System.Text;
using Domain.Domain.CreateRestaurantOp;
using Domain.Domain.GetRestaurantOp;
using Domain.Models;
using Domain.Queries;
using Infra.Free;
using LanguageExt;
using Persistence;
using Persistence.EfCore;
using Domain.Domain.CreateClientOp;
using Domain.Domain.CreateEmployeeOp;
using Domain.Domain.GetClientOp;
using Domain.Domain.GetEmployeeOp;
using Domain.Domain.CreateMenuOp;
using System.Data.SqlTypes;
using Domain.Domain.CreateMenuItemOp;
using Domain.Domain.GetMenusOp;
using Domain.Domain.PlaceOrderOp;
using Domain.Domain.CreateOrderItemOp;
using Domain.Domain.ChangeQuantityOp;
using Microsoft.VisualBasic;
using System.Linq;
using Domain.Domain.GetOrdersOp;
using Domain.Domain.GetOrderOp;
using Domain.Domain.GetOrderItemOp;
using Domain.Domain.GetMenuOp;
using Domain.Domain.GetMenuItemOp;
using Domain.Domain.GetOrderStatusOp;
using Domain.Domain.SetOrderStatusOp;
using Domain.Domain.CreatePaymentRequestOp;
using Domain.Domain.CheckOrderPaymentOp;
using Domain.Domain.PayOrderOp;
using Domain.Domain.GetOrderItemsOp;
using Domain.Domain.GetMenuItemsOp;

namespace Domain.Domain
{
    public static class RestaurantDomainEx
    {
        // Create a Restaurant
        public static IO<RestaurantAgg> CreateRestaurantAndPersist(string name, string address)
            => from restaurantCreated in RestaurantDomain.CreateRestaurant(name, address)
               let agg = (restaurantCreated as CreateRestaurantResult.RestaurantCreated)?.Restaurant
               from db in Database.AddOrUpdate(agg.Restaurant)               
               select agg;

        // Get a Restaurant by name
        public static IO<RestaurantAgg> GetRestaurant(string name)
            => from restaurant in Database.Query<FindRestaurantQuery, Restaurant>(new FindRestaurantQuery(name))
               from getResult in RestaurantDomain.GetRestaurant(restaurant)
               let agg = (getResult as GetRestaurantResult.RestaurantFound)?.Agg
               select agg;

        // Create a Client
        public static IO<ClientAgg> CreateClientAndPersist(string firstName, string lastName, string email, string phone, string cardNumber, string username, string password)
            => from clientCreated in RestaurantDomain.CreateClient(firstName, lastName, email, phone, cardNumber, username, password)
               let agg = (clientCreated as CreateClientResult.ClientCreated)?.Client
               from db in Database.AddOrUpdate(agg.Client)
               select agg;

        // Get a Client by Id
        public static IO<ClientAgg> GetClient(string clientId)
            => from client in Database.Query<FindClientQuery, Client>(new FindClientQuery(clientId))
               from getResult in RestaurantDomain.GetClient(client)
               let agg = (getResult as GetClientResult.ClientFound)?.Agg
               select agg;

        // Create an Employee
        public static IO<EmployeeAgg> CreateEmployeeAndPersist(string firstName, string lastName, string email, string phone, string job, string username, string password, int restaurantId)
            => from employeeCreated in RestaurantDomain.CreateEmployee(firstName, lastName, email, phone, job, username, password, restaurantId)
               let agg = (employeeCreated as CreateEmployeeResult.EmployeeCreated)?.Employee
               from db in Database.AddOrUpdate(agg.Employee)
               select agg;

        // Get an Employee by Restaurant Id and Employee Id 
        public static IO<EmployeeAgg> GetEmployee(int restaurantId, string employeeId)
            => from employee in Database.Query<FindEmployeeQuery, Employee>(new FindEmployeeQuery(restaurantId, employeeId))
               from getResult in RestaurantDomain.GetEmployee(employee)
               let agg = (getResult as GetEmployeeResult.EmployeeFound)?.Agg
               select agg;

        // Create a Menu
        public static IO<MenuAgg> CreateMenuAndPersist(string name, Restaurant restaurant)
            => from menuCreated in RestaurantDomain.CreateMenu(name, restaurant)
               let agg = (menuCreated as CreateMenuResult.MenuCreated)?.Menu
               from db in Database.AddOrUpdate(agg.Menu)
               select agg;

        // Get a Menu by Id
        public static IO<MenuAgg> GetMenu(int menuId)
            => from menu in Database.Query<FindMenuQuery, Menu>(new FindMenuQuery(menuId))
               from getResult in RestaurantDomain.GetMenu(menu)
               let agg = (getResult as GetMenuResult.MenuFound)?.Agg
               select agg;

        // Get Menus List from Restaurant
        public static IO<List<Menu>> GetMenus(Restaurant restaurant)
        => from menus in Database.Query<FindMenusQuery, List<Menu>>(new FindMenusQuery(restaurant))
           from getResult in RestaurantDomain.GetMenus(menus)
           let agg = (getResult as GetMenusResult.GetMenusSuccessful)?.Menus
           select agg;

        // Create a MenuItem
        public static IO<MenuItemAgg> CreateMenuItemAndPersist(Menu menu, string name, string ingredients, string allergens, uint totalQuantity, decimal price, bool availability)
            => from menuItemCreated in RestaurantDomain.CreateMenuItem(menu, name, ingredients, allergens, totalQuantity, price, availability)
               let agg = (menuItemCreated as CreateMenuItemResult.MenuItemCreated)?.MenuItem
               from db in Database.AddOrUpdate(agg.MenuItem)
               select agg;

        // Get a MenuItem by Id
        public static IO<MenuItemAgg> GetMenuItem(int menuItemId)
            => from menuItem in Database.Query<FindMenuItemQuery, MenuItem>(new FindMenuItemQuery(menuItemId))
               from getResult in RestaurantDomain.GetMenuItem(menuItem)
               let agg = (getResult as GetMenuItemResult.MenuItemFound)?.Agg
               select agg;

        // Get Menu Items List for a specific Menu
        public static IO<List<MenuItem>> GetMenuItems(Menu menu)
        => from menuItems in Database.Query<FindMenuItemsQuery, List<MenuItem>>(new FindMenuItemsQuery(menu))
           from getResult in RestaurantDomain.GetMenuItems(menuItems)
           let agg = (getResult as GetMenuItemsResult.MenuItemsFound)?.MenuItems
           select agg;

        // Change a MenuItem
        public static IO<MenuItemAgg> ChangeMenuItemAndPersist(MenuItem menuItem, MenuItem newMenuItem)
            => from menuItemChanged in RestaurantDomain.ChangeMenuItem(menuItem, newMenuItem)
               let agg = (menuItemChanged as CreateMenuItemResult.MenuItemCreated)?.MenuItem
               from db in Database.AddOrUpdate(agg.MenuItem)
               select agg;

        // Add to Cart => Create an OrderItem
        /*public static IO<CreateOrderItemResult.IAddToCartResult> AddToCart(string sessionId, MenuItem menuItem, uint quantity, string specialRequests)
            => from orderItemCreated in RestaurantDomain.AddToCart(sessionId, menuItem, quantity, specialRequests)
               let agg = (orderItemCreated as CreateOrderItemResult.AddToCartSuccessful)?.OrderItem
               from db in Database.AddOrUpdate(agg.OrderItem)
               select orderItemCreated;*/

        // Place Order => Create an Order
        public static IO<OrderAgg> PlaceOrderAndPersist(Client client, Restaurant restaurant, decimal totalPrice, uint tableNumber)
            => from orderCreated in RestaurantDomain.PlaceOrder(client, restaurant, totalPrice, tableNumber)
               let agg = (orderCreated as PlaceOrderResult.OrderPlaced)?.Order
               from db in Database.AddOrUpdate(agg.Order)
               select agg;

        // Get an Order by Id
        public static IO<OrderAgg> GetOrder(int orderId)
            => from order in Database.Query<FindOrderQuery, Order>(new FindOrderQuery(orderId))
               from getResult in RestaurantDomain.GetOrder(order)
               let agg = (getResult as GetOrderResult.OrderFound)?.Agg
               select agg;

        // Create an OrderItem
        public static IO<OrderItemAgg> CreateOrderItemAndPersist(CartItem cartItem, Order order)
            => from orderItemCreated in RestaurantDomain.CreateOrderItem(cartItem, order)
               let agg = (orderItemCreated as CreateOrderItemResult.OrderItemCreated)?.OrderItem
               from db in Database.AddOrUpdate(agg.OrderItem)
               select agg;

        // Get an OrderItem by Id
        public static IO<OrderItemAgg> GetOrderItem(int orderItemId)
            => from orderItem in Database.Query<FindOrderItemQuery, OrderItem>(new FindOrderItemQuery(orderItemId))
               from getResult in RestaurantDomain.GetOrderItem(orderItem)
               let agg = (getResult as GetOrderItemResult.OrderItemFound)?.Agg
               select agg;

        // Get Order Items from an Order
        public static IO<List<OrderItem>> GetOrderItems(Order order)
            => from orderItems in Database.Query<FindOrderItemsQuery, List<OrderItem>>(new FindOrderItemsQuery(order))
               from getResult in RestaurantDomain.GetOrderItems(orderItems)
               let agg = (getResult as GetOrderItemsResult.OrderItemsFound)?.OrderItems
               select agg;

        // Change quantity of an OrderItem
        public static IO<OrderItemAgg> ChangeQuantityAndPersist(string sessionId, OrderItem orderItem, uint newQuantity)
            => from quantityChanged in RestaurantDomain.ChangeQuantity(sessionId, orderItem, newQuantity)
               let agg = (quantityChanged as ChangeQuantityResult.QuantityChanged)?.NewOrderItem
               from db in Database.AddOrUpdate(agg.OrderItem)
               select agg;

        // Get Orders from a specific Restaurant       
        public static IO<List<Order>> GetRestaurantOrders(Restaurant restaurant)
            => from orders in Database.Query<FindOrdersQuery, List<Order>>(new FindOrdersQuery(restaurant))
               from getResult in RestaurantDomain.GetOrders(orders)
               let agg = (getResult as GetOrdersResult.GetOrdersSuccessful)?.Orders
               select agg;

        // Get Orders from a specific Client
        public static IO<List<Order>> GetClientOrders(int clientId)
            => from orders in Database.Query<FindClientOrdersQuery, List<Order>>(new FindClientOrdersQuery(clientId))
               from getResult in RestaurantDomain.GetOrders(orders)
               let agg = (getResult as GetOrdersResult.GetOrdersSuccessful)?.Orders
               select agg;

        // Get status for a specific Order by Id
        public static IO<string> GetOrderStatus(int orderId)
            => from order in Database.Query<FindOrderQuery, Order>(new FindOrderQuery(orderId))
               from getResult in RestaurantDomain.GetOrderStatus(order)
               let status = (getResult as GetOrderStatusResult.GetOrderStatus)?.StatusMessage
               select status;

        // Set status for a specific Order
        public static IO<OrderAgg> SetOrderStatusAndPersist(Order order, string orderStatus, TimeSpan preparationTime)
            => from statusCreated in RestaurantDomain.SetOrderStatus(order, orderStatus, preparationTime)
               let agg = (statusCreated as SetOrderStatusResult.SetOrderStatusSuccessful)?.Order
               from db in Database.AddOrUpdate(agg.Order)
               select agg;

        // Create a payment request for an Order
        public static IO<OrderAgg> CreatePaymentRequestAndPersist(int orderId)
            => from order in Database.Query<FindOrderQuery, Order>(new FindOrderQuery(orderId))
               from requestCreated in RestaurantDomain.CreatePaymentRequest(order)
               let agg = (requestCreated as CreatePaymentRequestResult.PaymentOrderStatus)?.Order
               from db in Database.AddOrUpdate(agg.Order)
               select agg;

        // Check payment status for a specific Order
        public static IO<string> CheckOrderPaymentStatus(int orderId)
            => from order in Database.Query<FindOrderQuery, Order>(new FindOrderQuery(orderId))
               from getResult in RestaurantDomain.CheckOrderPaymentStatus(order)
               let status = (getResult as CheckOrderPaymentResult.CheckOrderPaymentStatus)?.PaymentStatus
               select status;

        // Pay an Order
        public static IO<OrderAgg> PayOrderAndPersist(Client client, Order order, uint tip)
            => from orderPaid in RestaurantDomain.PayOrder(client, order, tip)
               let agg = (orderPaid as PayOrderResult.OrderPaid)?.Order
               from db in Database.AddOrUpdate(agg.Order)
               select agg;
    }
}
