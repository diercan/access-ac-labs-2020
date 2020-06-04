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
using static Domain.Domain.GetRestaurantOp.GetRestaurantResult;
using static Domain.Domain.GetEmployeeOp.GetEmployeeResult;
using static Domain.Domain.CreateMenuOp.CreateMenuResult;
using static Domain.Domain.GetMenusOp.GetMenusResult;
using static Domain.Domain.CreateMenuItemOp.CreateMenuItemResult;
using static Domain.Domain.ChangeMenuItemOp.ChangeMenuItemResult;
using static Domain.Domain.ClientRoles.AddToCartOp.AddToCartResult;
using static Domain.Domain.CreateOrderItemOp.CreateOrderItemResult;
using static Domain.Domain.PlaceOrderOp.PlaceOrderResult;
using static Domain.Domain.ChangeQuantityOp.ChangeQuantityResult;
using static Domain.Domain.GetOrdersOp.GetOrdersResult;
using static Domain.Domain.GetOrderStatusOp.GetOrderStatusResult;
using Domain.Domain.GetOrderOp;
using static Domain.Domain.GetOrderOp.GetOrderResult;
using static Domain.Domain.GetOrderItemOp.GetOrderItemResult;
using Domain.Domain.GetOrderItemOp;
using static Domain.Domain.GetClientOp.GetClientResult;
using static Domain.Domain.GetMenuOp.GetMenuResult;
using Domain.Domain.GetMenuOp;
using Domain.Domain.GetMenuItemOp;
using static Domain.Domain.GetMenuItemOp.GetMenuItemResult;
using static Domain.Domain.SetOrderStatusOp.SetOrderStatusResult;
using static Domain.Domain.CheckOrderPaymentOp.CheckOrderPaymentResult;
using static Domain.Domain.CreatePaymentRequestOp.CreatePaymentRequestResult;
using static Domain.Domain.PayOrderOp.PayOrderResult;
using static Domain.Domain.GetMenuItemsOp.GetMenuItemsResult;
using Domain.Domain.GetMenuItemsOp;
using static Domain.Domain.GetOrderItemsOp.GetOrderItemsResult;
using Domain.Domain.GetOrderItemsOp;

namespace Domain.Domain
{
    public static class RestaurantDomain
    {
        // CREATE RESTAURANT
        public static IO<ICreateRestaurantResult> CreateRestaurant(string name, string address) =>
            NewIO<CreateRestaurantCmd, ICreateRestaurantResult>(new CreateRestaurantCmd(name, address));

        public static IO<ICreateRestaurantResult> CreateRestaurantAndPersist(string name, string address)
            => from restaurantCreated in RestaurantDomain.CreateRestaurant(name, address)
               let agg = (restaurantCreated as CreateRestaurantResult.RestaurantCreated)?.Restaurant
               from db in Database.AddOrUpdate(agg.Restaurant)
               select restaurantCreated;

        // GET RESTAURANT
        public static IO<IGetRestaurantResult> GetRestaurant(Restaurant restaurant) =>
             NewIO<GetRestaurantCmd, GetRestaurantResult.IGetRestaurantResult>(new GetRestaurantCmd(restaurant));

        public static IO<IGetRestaurantResult> GetRestaurant(string name)
            => from restaurant in Database.Query<FindRestaurantQuery, Restaurant>(new FindRestaurantQuery(name))
               from getResult in RestaurantDomain.GetRestaurant(restaurant)
               let agg = (getResult as GetRestaurantResult.RestaurantFound)?.Agg
               select getResult;

        // CREATE CLIENT
        public static IO<ICreateClientResult> CreateClient(string firstName, string lastName, string email, string phone, string cardNumber, string clientId, string password) =>
            NewIO<CreateClientCmd, ICreateClientResult>(new CreateClientCmd(firstName, lastName, email, phone, cardNumber, clientId, password));

        public static IO<ICreateClientResult> CreateClientAndPersist(string firstName, string lastName, string email, string phone, string cardNumber, string username, string password)
            => from clientCreated in RestaurantDomain.CreateClient(firstName, lastName, email, phone, cardNumber, username, password)
               let agg = (clientCreated as CreateClientResult.ClientCreated)?.Client
               from db in Database.AddOrUpdate(agg.Client)
               select clientCreated;

        // GET CLIENT
        public static IO<IGetClientResult> GetClient(Client client) =>
            NewIO<GetClientCmd, GetClientResult.IGetClientResult>(new GetClientCmd(client));

        public static IO<IGetClientResult> GetClient(string clientId)
           => from client in Database.Query<FindClientQuery, Client>(new FindClientQuery(clientId))
              from getResult in RestaurantDomain.GetClient(client)
              let agg = (getResult as GetClientResult.ClientFound)?.Agg
              select getResult;

        // CREATE EMPLOYEE
        public static IO<ICreateEmployeeResult> CreateEmployee(string firstName, string lastName, string email, string phone, string job, string employeeId, string password, int restaurantId) =>
            NewIO<CreateEmployeeCmd, ICreateEmployeeResult>(new CreateEmployeeCmd(firstName, lastName, email, phone, job, employeeId, password, restaurantId));

        public static IO<ICreateEmployeeResult> CreateEmployeeAndPersist(string firstName, string lastName, string email, string phone, string job, string username, string password, int restaurantId)
            => from employeeCreated in RestaurantDomain.CreateEmployee(firstName, lastName, email, phone, job, username, password, restaurantId)
               let agg = (employeeCreated as CreateEmployeeResult.EmployeeCreated)?.Employee
               from db in Database.AddOrUpdate(agg.Employee)
               select employeeCreated;

        // GET EMPLOYEE
        public static IO<IGetEmployeeResult> GetEmployee(Employee employee) =>
            NewIO<GetEmployeeCmd, GetEmployeeResult.IGetEmployeeResult>(new GetEmployeeCmd(employee));

        public static IO<IGetEmployeeResult> GetEmployee(int restaurantId, string employeeId)
        => from employee in Database.Query<FindEmployeeQuery, Employee>(new FindEmployeeQuery(restaurantId, employeeId))
           from getResult in RestaurantDomain.GetEmployee(employee)
           let agg = (getResult as GetEmployeeResult.EmployeeFound)?.Agg
           select getResult;

        // CREATE MENU
        public static IO<ICreateMenuResult> CreateMenu(string name, Restaurant restaurant) =>
            NewIO<CreateMenuCmd, CreateMenuResult.ICreateMenuResult>(new CreateMenuCmd(name, restaurant));

        public static IO<ICreateMenuResult> CreateMenuAndPersist(string name, Restaurant restaurant)
           => from menuCreated in RestaurantDomain.CreateMenu(name, restaurant)
              let agg = (menuCreated as CreateMenuResult.MenuCreated)?.Menu
              from db in Database.AddOrUpdate(agg.Menu)
              select menuCreated;

        // GET MENU
        public static IO<IGetMenuResult> GetMenu(Menu menu) =>
            NewIO<GetMenuCmd, GetMenuResult.IGetMenuResult>(new GetMenuCmd(menu));

        public static IO<IGetMenuResult> GetMenu(int menuId)
            => from menu in Database.Query<FindMenuQuery, Menu>(new FindMenuQuery(menuId))
               from getResult in RestaurantDomain.GetMenu(menu)
               let agg = (getResult as GetMenuResult.MenuFound)?.Agg
               select getResult;

        // GET MENUS
        public static IO<IGetMenusResult> GetMenus(List<Menu> menus) =>
            NewIO<GetMenusCmd, GetMenusResult.IGetMenusResult>(new GetMenusCmd(menus));

        public static IO<IGetMenusResult> GetMenus(Restaurant restaurant)
            => from menus in Database.Query<FindMenusQuery, List<Menu>>(new FindMenusQuery(restaurant))
               from getResult in RestaurantDomain.GetMenus(menus)
               let agg = (getResult as GetMenusResult.GetMenusSuccessful)?.Menus
               select getResult;

        // CREATE MENU ITEM
        public static IO<ICreateMenuItemResult> CreateMenuItem(Menu menu, string name, string ingredients, string allergens, uint totalQuantity, decimal price, bool availability) =>
            NewIO<CreateMenuItemCmd, CreateMenuItemResult.ICreateMenuItemResult>(new CreateMenuItemCmd(menu, name, ingredients, allergens, totalQuantity, price, availability));
            
        public static IO<ICreateMenuItemResult> CreateMenuItemAndPersist(Menu menu, string name, string ingredients, string allergens, uint totalQuantity, decimal price, bool availability)
            => from menuItemCreated in RestaurantDomain.CreateMenuItem(menu, name, ingredients, allergens, totalQuantity, price, availability)
               let agg = (menuItemCreated as CreateMenuItemResult.MenuItemCreated)?.MenuItem
               from db in Database.AddOrUpdate(agg.MenuItem)
               select menuItemCreated;

        // GET MENU ITEM
        public static IO<IGetMenuItemResult> GetMenuItem(MenuItem menuItem) =>
            NewIO<GetMenuItemCmd, GetMenuItemResult.IGetMenuItemResult>(new GetMenuItemCmd(menuItem));

        public static IO<IGetMenuItemResult> GetMenuItem(int menuItemId)
            => from menuItem in Database.Query<FindMenuItemQuery, MenuItem>(new FindMenuItemQuery(menuItemId))
               from getResult in RestaurantDomain.GetMenuItem(menuItem)
               let agg = (getResult as GetMenuItemResult.MenuItemFound)?.Agg
               select getResult;

        // GET MENU ITEMS
        public static IO<IGetMenuItemsResult> GetMenuItems(List<MenuItem> menuItems) =>
            NewIO<GetMenuItemsCmd, GetMenuItemsResult.IGetMenuItemsResult>(new GetMenuItemsCmd(menuItems));

        public static IO<IGetMenuItemsResult> GetMenuItems(Menu menu)
            => from menuItems in Database.Query<FindMenuItemsQuery, List<MenuItem>>(new FindMenuItemsQuery(menu))
               from getResult in RestaurantDomain.GetMenuItems(menuItems)
               let agg = (getResult as GetMenuItemsResult.MenuItemsFound)?.MenuItems
               select getResult;

        // CHANGE MENU ITEM
        public static IO<IChangeMenuItemResult> ChangeMenuItem(MenuItem menuItem, MenuItem newMenuItem) =>
            NewIO<ChangeMenuItemCmd, ChangeMenuItemResult.IChangeMenuItemResult>(new ChangeMenuItemCmd(menuItem, newMenuItem));

        public static IO<IChangeMenuItemResult> ChangeMenuItemAndPersist(MenuItem menuItem, MenuItem newMenuItem)
            => from menuItemChanged in RestaurantDomain.ChangeMenuItem(menuItem, newMenuItem)
               let agg = (menuItemChanged as ChangeMenuItemResult.MenuItemChanged)?.NewMenuItem
               from db in Database.AddOrUpdate(agg.MenuItem)
               select menuItemChanged;

        // ADD TO CART => 
        public static IO<IAddToCartResult> AddToCart(string sessionId, MenuItem menuItem, uint quantity, string specialRequests) =>
            NewIO<AddToCartCmd, AddToCartResult.IAddToCartResult>(new AddToCartCmd(sessionId, menuItem, quantity, specialRequests));

        // PLACE ORDER => ORDER
        public static IO<IPlaceOrderResult> PlaceOrder(Client client, Restaurant restaurant, decimal totalPrice, uint tableNumber) =>
            NewIO<PlaceOrderCmd, PlaceOrderResult.IPlaceOrderResult>(new PlaceOrderCmd(client, restaurant, totalPrice, tableNumber));

        public static IO<IPlaceOrderResult> PlaceOrderAndPersist(Client client, Restaurant restaurant, decimal totalPrice, uint tableNumber)
            => from orderCreated in RestaurantDomain.PlaceOrder(client, restaurant, totalPrice, tableNumber)
               let agg = (orderCreated as PlaceOrderResult.OrderPlaced)?.Order
               from db in Database.AddOrUpdate(agg.Order)
               select orderCreated;

        // GET ORDER
        public static IO<IGetOrderResult> GetOrder(Order order) =>
            NewIO<GetOrderCmd, GetOrderResult.IGetOrderResult>(new GetOrderCmd(order));

        public static IO<IGetOrderResult> GetOrder(int orderId)
            => from order in Database.Query<FindOrderQuery, Order>(new FindOrderQuery(orderId))
               from getResult in RestaurantDomain.GetOrder(order)
               let agg = (getResult as GetOrderResult.OrderFound)?.Agg
               select getResult;

        // CREATE ORDER ITEM
        public static IO<ICreateOrderItemResult> CreateOrderItem(CartItem cartItem, Order order) =>
            NewIO<CreateOrderItemCmd, CreateOrderItemResult.ICreateOrderItemResult>(new CreateOrderItemCmd(cartItem, order));

        public static IO<ICreateOrderItemResult> CreateOrderItemAndPersist(CartItem cartItem, Order order)
            => from orderItemCreated in RestaurantDomain.CreateOrderItem(cartItem, order)
               let agg = (orderItemCreated as CreateOrderItemResult.OrderItemCreated)?.OrderItem
               from db in Database.AddOrUpdate(agg.OrderItem)
               select orderItemCreated;

        // GET ORDER ITEM
        public static IO<IGetOrderItemResult> GetOrderItem(OrderItem orderItem) =>
            NewIO<GetOrderItemCmd, GetOrderItemResult.IGetOrderItemResult>(new GetOrderItemCmd(orderItem));

        public static IO<IGetOrderItemResult> GetOrderItem(int orderItemId)
            => from orderItem in Database.Query<FindOrderItemQuery, OrderItem>(new FindOrderItemQuery(orderItemId))
               from getResult in RestaurantDomain.GetOrderItem(orderItem)
               let agg = (getResult as GetOrderItemResult.OrderItemFound)?.Agg
               select getResult;

        //GET ORDER ITEMS
        public static IO<IGetOrderItemsResult> GetOrderItems(List<OrderItem> orderItems) =>
            NewIO<GetOrderItemsCmd, GetOrderItemsResult.IGetOrderItemsResult>(new GetOrderItemsCmd(orderItems));

        public static IO<IGetOrderItemsResult> GetOrderItems(Order order)
            => from orderItems in Database.Query<FindOrderItemsQuery, List<OrderItem>>(new FindOrderItemsQuery(order))
               from getResult in RestaurantDomain.GetOrderItems(orderItems)
               let agg = (getResult as GetOrderItemsResult.OrderItemsFound)?.OrderItems
               select getResult;

        // CHANGE QUANTITY
        public static IO<IChangeQuantityResult> ChangeQuantity(string sessionId, OrderItem orderItem, uint newQuantity) =>
            NewIO<ChangeQuantityCmd, ChangeQuantityResult.IChangeQuantityResult>(new ChangeQuantityCmd(sessionId, orderItem, newQuantity));

        public static IO<IChangeQuantityResult> ChangeQuantityAndPersist(string sessionId, OrderItem orderItem, uint newQuantity)
            => from quantityChanged in RestaurantDomain.ChangeQuantity(sessionId, orderItem, newQuantity)
               let agg = (quantityChanged as ChangeQuantityResult.QuantityChanged)?.NewOrderItem
               from db in Database.AddOrUpdate(agg.OrderItem)
               select quantityChanged;       

        // GET ORDERS
        public static IO<IGetOrdersResult> GetOrders(List<Order> orders) =>
            NewIO<GetOrdersCmd, GetOrdersResult.IGetOrdersResult>(new GetOrdersCmd(orders));

        public static IO<IGetOrdersResult> GetRestaurantOrders(Restaurant restaurant)
        => from orders in Database.Query<FindOrdersQuery, List<Order>>(new FindOrdersQuery(restaurant))
           from getResult in RestaurantDomain.GetOrders(orders)
           let agg = (getResult as GetOrdersResult.GetOrdersSuccessful)?.Orders
           select getResult;

        public static IO<IGetOrdersResult> GetOrders(int clientId)
        => from orders in Database.Query<FindClientOrdersQuery, List<Order>>(new FindClientOrdersQuery(clientId))
           from getResult in RestaurantDomain.GetOrders(orders)
           let agg = (getResult as GetOrdersResult.GetOrdersSuccessful)?.Orders
           select getResult;

        // GET ORDER STATUS
        public static IO<IGetOrderStatusResult> GetOrderStatus(Order order) =>
            NewIO<GetOrderStatusCmd, GetOrderStatusResult.IGetOrderStatusResult>(new GetOrderStatusCmd(order));
        
        public static IO<IGetOrderStatusResult> GetOrderStatus(int orderId)
            => from order in Database.Query<FindOrderQuery, Order>(new FindOrderQuery(orderId))
               from getResult in RestaurantDomain.GetOrderStatus(order)
               let status = (getResult as GetOrderStatusResult.GetOrderStatus)?.StatusMessage
               select getResult;

        // SET ORDER STATUS
        public static IO<ISetOrderStatusResult> SetOrderStatus(Order order, string orderStatus, TimeSpan preparationTime) =>
            NewIO<SetOrderStatusCmd, SetOrderStatusResult.ISetOrderStatusResult>(new SetOrderStatusCmd(order, orderStatus, preparationTime));

        public static IO<ISetOrderStatusResult> SetOrderStatusAndPersist(Order order, string orderStatus, TimeSpan preparationTime)
            => from statusCreated in RestaurantDomain.SetOrderStatus(order, orderStatus, preparationTime)
               let agg = (statusCreated as SetOrderStatusResult.SetOrderStatusSuccessful)?.Order
               from db in Database.AddOrUpdate(agg.Order)
               select statusCreated;

        // CREATE PAYMENT REQUEST
        public static IO<ICreatePaymentRequestResult> CreatePaymentRequest(Order order) =>
            NewIO<CreatePaymentRequestCmd, CreatePaymentRequestResult.ICreatePaymentRequestResult>(new CreatePaymentRequestCmd(order));

        public static IO<ICreatePaymentRequestResult> CreatePaymentRequestAndPersist(int orderId)
            => from order in Database.Query<FindOrderQuery, Order>(new FindOrderQuery(orderId))
               from requestCreated in RestaurantDomain.CreatePaymentRequest(order)
               let agg = (requestCreated as CreatePaymentRequestResult.PaymentOrderStatus)?.Order
               from db in Database.AddOrUpdate(agg.Order)
               select requestCreated;

        // CHECK ORDER PAYMENT STATUS
        public static IO<ICheckOrderPaymentResult> CheckOrderPaymentStatus(Order order) =>
            NewIO<CheckOrderPaymentCmd, CheckOrderPaymentResult.ICheckOrderPaymentResult>(new CheckOrderPaymentCmd(order));

        public static IO<ICheckOrderPaymentResult> CheckOrderPaymentStatus(int orderId)
            => from order in Database.Query<FindOrderQuery, Order>(new FindOrderQuery(orderId))
               from getResult in RestaurantDomain.CheckOrderPaymentStatus(order)
               let status = (getResult as CheckOrderPaymentResult.CheckOrderPaymentStatus)?.PaymentStatus
               select getResult;

        // PAY ORDER
        public static IO<IPayOrderResult> PayOrder(Client client, Order order, uint tip) =>
            NewIO<PayOrderCmd, PayOrderResult.IPayOrderResult>(new PayOrderCmd(client, order, tip));

        public static IO<IPayOrderResult> PayOrderAndPersist(Client client, Order order, uint tip)
            => from orderPaid in RestaurantDomain.PayOrder(client, order, tip)
               let agg = (orderPaid as PayOrderResult.OrderPaid)?.Order
               from db in Database.AddOrUpdate(agg.Order)
               select orderPaid;
    }
}
