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

namespace Domain.Domain
{
    public static class RestaurantDomainEx
    {
        // Create a Restaurant
        public static IO<CreateRestaurantResult.ICreateRestaurantResult> CreateRestaurantAndPersist(string name, string address)
            => from restaurantCreated in RestaurantDomain.CreateRestaurant(name, address)
               let agg = (restaurantCreated as CreateRestaurantResult.RestaurantCreated)?.Restaurant
               from db in Database.AddOrUpdate(agg.Restaurant)               
               select restaurantCreated;

        // Get a Restaurant by name
        public static IO<RestaurantAgg> GetRestaurant(string name)
            => from restaurant in Database.Query<FindRestaurantQuery, Restaurant>(new FindRestaurantQuery(name))
               from getResult in RestaurantDomain.GetRestaurant(restaurant)
               let agg = (getResult as GetRestaurantResult.RestaurantFound)?.Agg
               select agg;

        // Create a Client
        public static IO<CreateClientResult.ICreateClientResult> CreateClientAndPersist(string firstName, string lastName, string email, string phone, string cardNumber, string username, string password)
            => from clientCreated in RestaurantDomain.CreateClient(firstName, lastName, email, phone, cardNumber, username, password)
               let agg = (clientCreated as CreateClientResult.ClientCreated)?.Client
               from db in Database.AddOrUpdate(agg.Client)
               select clientCreated;

        // Get a Client by Id
        public static IO<ClientAgg> GetClient(string clientId)
            => from client in Database.Query<FindClientQuery, Client>(new FindClientQuery(clientId))
               from getResult in RestaurantDomain.GetClient(client)
               let agg = (getResult as GetClientResult.ClientFound)?.Agg
               select agg;

        // Create an Employee
        public static IO<CreateEmployeeResult.ICreateEmployeeResult> CreateEmployeeAndPersist(string firstName, string lastName, string email, string phone, string job, string username, string password, int restaurantId)
            => from employeeCreated in RestaurantDomain.CreateEmployee(firstName, lastName, email, phone, job, username, password, restaurantId)
               let agg = (employeeCreated as CreateEmployeeResult.EmployeeCreated)?.Employee
               from db in Database.AddOrUpdate(agg.Employee)
               select employeeCreated;

        // Get an Employee by Restaurant Id and Employee Id 
        public static IO<EmployeeAgg> GetEmployee(int restaurantId, string employeeId)
            => from employee in Database.Query<FindEmployeeQuery, Employee>(new FindEmployeeQuery(restaurantId, employeeId))
               from getResult in RestaurantDomain.GetEmployee(employee)
               let agg = (getResult as GetEmployeeResult.EmployeeFound)?.Agg
               select agg;

        // Create a Menu
        public static IO<CreateMenuResult.ICreateMenuResult> CreateMenuAndPersist(string name, Restaurant restaurant)
            => from menuCreated in RestaurantDomain.CreateMenu(name, restaurant)
               let agg = (menuCreated as CreateMenuResult.MenuCreated)?.Menu
               from db in Database.AddOrUpdate(agg.Menu)
               select menuCreated;

        //  Get Menus from a specific Restaurant
        public static IO<ICollection<Menu>> GetMenus(Restaurant restaurant)
            => from menus in Database.Query<FindMenusQuery, ICollection<Menu>>(new FindMenusQuery(restaurant))               
               //from getMenus in RestaurantDomain.GetMenus(restaurant)
               //let menu = (getMenus as GetMenusResult.GetMenusSuccessful)?.Menus
               select menus;

        // Create a MenuItem
        public static IO<CreateMenuItemResult.ICreateMenuItemResult> CreateMenuItemAndPersist(Menu menu, string name, string ingredients, string allergens, uint totalQuantity, double price, bool availability)
            => from menuItemCreated in RestaurantDomain.CreateMenuItem(menu, name, ingredients, allergens, totalQuantity, price, availability)
               let agg = (menuItemCreated as CreateMenuItemResult.MenuItemCreated)?.MenuItem
               from db in Database.AddOrUpdate(agg.MenuItem)
               select menuItemCreated;

        // Add to Cart => Create an OrderItem
        /*public static IO<CreateOrderItemResult.IAddToCartResult> AddToCart(string sessionId, MenuItem menuItem, uint quantity, string specialRequests)
            => from orderItemCreated in RestaurantDomain.AddToCart(sessionId, menuItem, quantity, specialRequests)
               let agg = (orderItemCreated as CreateOrderItemResult.AddToCartSuccessful)?.OrderItem
               from db in Database.AddOrUpdate(agg.OrderItem)
               select orderItemCreated;*/

        // Place Order => Create an Order
        public static IO<PlaceOrderResult.IPlaceOrderResult> PlaceOrder(Client client, Restaurant restaurant, double totalPrice, uint tableNumber)
            => from orderCreated in RestaurantDomain.PlaceOrder(client, restaurant, totalPrice, tableNumber)
               let agg = (orderCreated as PlaceOrderResult.OrderPlaced)?.Order
               from db in Database.AddOrUpdate(agg.Order)
               select orderCreated;

        // Create an OrderItem
        public static IO<CreateOrderItemResult.ICreateOrderItemResult> CreateOrderItem(CartItem cartItem, Order order)
            => from orderItemCreated in RestaurantDomain.CreateOrderItem(cartItem, order)
               let agg = (orderItemCreated as CreateOrderItemResult.OrderItemCreated)?.OrderItem
               from db in Database.AddOrUpdate(agg.OrderItem)
               select orderItemCreated;
    }
}
