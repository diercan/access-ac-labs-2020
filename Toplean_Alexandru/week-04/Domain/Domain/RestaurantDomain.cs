using Domain.Domain.CreateRestauratOp;
using Infra.Free;
using static IOExt;
using static Domain.Domain.CreateRestauratOp.CreateRestaurantResult;
using Persistence;
using Domain.Models;
using Persistence.EfCore;
using Domain.Queries;
using static Domain.Domain.SelectRestaurantOp.SelectRestaurantResult;
using System;
using Domain.Domain.SelectRestaurantOp;

using Domain.Domain.CreateMenuOp;
using static Domain.Domain.CreateMenuOp.CreateMenuResult;
using System.Collections.Generic;
using static Domain.Domain.SelectMenuOp.SelectMenuResult;
using Domain.Domain.SelectMenuOp;
using static Domain.Domain.CreateMenuItemOp.CreateMenuItemResult;
using Domain.Domain.CreateMenuItemOp;
using static Domain.Domain.SelectMenuItemOp.SelectMenuItemResult;
using Domain.Domain.SelectMenuItemOp;
using static Domain.Domain.CreateClientOp.CreateClientResult;
using Domain.Domain.CreateClientOp;
using Domain.Domain.SelectClientOp;
using static Domain.Domain.SelectClientOp.SelectClientResult;
using static Domain.Domain.CreateOrderOp.CreateOrderResult;
using Domain.Domain.CreateOrderOp;
using static Domain.Domain.AddToCartOp.AddToCartResult;
using static Domain.Domain.ChangeQuantityOp.ChangeQuantityResult;
using static Domain.Domain.SetOrderStatusOp.SetOrderStatusResult;
using static Domain.Models.Cart;
using static Domain.Domain.GetPaymentStatusOp.GetPaymentStatusResult;
using static Domain.Domain.RequestPaymentOp.RequestPaymentResult;

namespace Domain.Domain
{
    public static class RestaurantDomain
    {
        //========================================== Creates =========================================================
        public static IO<ICreateRestaurantResult> CreateRestaurant(string name) =>
            NewIO<CreateRestaurantCmd, ICreateRestaurantResult>(new CreateRestaurantCmd(name));

        public static IO<ICreateMenuResult> CreateMenu(int id, string name, String menuType, bool isVisible, String hours, Restaurant restaurant) =>
           NewIO<CreateMenuCmd, ICreateMenuResult>(new CreateMenuCmd(id, name, menuType, isVisible, hours, restaurant));

        public static IO<ICreateMenuItemResult> CreateMenuItem(int menuid, string name, double price, String ingredients, String? alergens, byte[] image) =>
           NewIO<CreateMenuItemCmd, ICreateMenuItemResult>(new CreateMenuItemCmd(menuid, name, price, ingredients, alergens, image));

        public static IO<ICreateClientResult> CreateClient(String name, String username, String password, String email) =>
          NewIO<CreateClientCmd, ICreateClientResult>(new CreateClientCmd(name, username, password, email));

        public static IO<ICreateOrderResult> CreateOrder(int clientId, int restaurantId, int tableNumber, String itemNames, String itemQuantities, String itemComments, double totalPrice, String status, String payment) =>
          NewIO<CreateOrderCmd, ICreateOrderResult>(new CreateOrderCmd(clientId, restaurantId, tableNumber, itemNames, itemQuantities, itemComments, totalPrice, status, payment));

        //=============================================== Creates and persists ============================================
        public static IO<CreateRestaurantResult.ICreateRestaurantResult> CreateAndPersist(string name) =>
            from restaurantCreated in RestaurantDomain.CreateRestaurant(name)
            let restaurantAgg = (restaurantCreated as RestaurantCreated)?.Restaurant
            from dbContext in Database.AddNewEntity(restaurantAgg.Restaurant)
            select restaurantCreated;

        public static IO<ICreateMenuResult> CreateAndPersistMenu(int id, string name, String menuType, bool isVisible, String hours, Restaurant restaurant) =>
           from menuCreated in RestaurantDomain.CreateMenu(id, name, menuType, isVisible, hours, restaurant)
           let menuAgg = (menuCreated as MenuCreated)?.Menu
           from dbContext in Database.AddNewEntity(menuAgg.Menu)
           select menuCreated;

        public static IO<ICreateMenuItemResult> CreateAndPersistMenuItem(int menuid, string name, double price, String ingredients, String? alergens, byte[] image) =>
           from menuItemCreated in RestaurantDomain.CreateMenuItem(menuid, name, price, ingredients, alergens, image)
           let menuItemAgg = (menuItemCreated as MenuItemCreated)?.MenuItemAgg
           from dbContext in Database.AddNewEntity(menuItemAgg.MenuItem)
           select menuItemCreated;

        public static IO<ICreateClientResult> CreateAndPersistClient(String name, String username, String password, String email) =>
           from clientCreated in RestaurantDomain.CreateClient(name, username, password, email)
           let clientAgg = (clientCreated as ClientCreated)?.Client
           from dbContext in Database.AddNewEntity(clientAgg.Client)
           select clientCreated;

        public static IO<ICreateOrderResult> CreateAndPersistOrder(int clientId, int restaurantId, int tableNumber, String itemNames, String itemQuantities, String itemComments, double totalPrice, String status, String payment) =>
           from orderCreated in RestaurantDomain.CreateOrder(clientId, restaurantId, tableNumber, itemNames, itemQuantities, itemComments, totalPrice, status, payment)
           let orderAgg = (orderCreated as OrderCreated)?.OrderAgg
           from dbContext in Database.AddNewEntity(orderAgg.Order)
           select orderCreated;

        // ===================================================== Selects ================================================
        public static IO<ISelectRestaurantResult> SelectRestaurant(Restaurant restaurant) =>
           NewIO<SelectRestaurantCmd, ISelectRestaurantResult>(new SelectRestaurantCmd(restaurant));

        public static IO<ISelectMenuResult> SelectMenu(Menu menu) =>
            NewIO<SelectMenuCmd, ISelectMenuResult>(new SelectMenuCmd(menu));

        public static IO<ISelectMenuItemResult> SelectMenuItem(MenuItem menuItem) =>
            NewIO<SelectMenuItemCmd, ISelectMenuItemResult>(new SelectMenuItemCmd(menuItem));

        public static IO<ISelectClientResult> SelectClient(Client client) =>
            NewIO<SelectClientCmd, ISelectClientResult>(new SelectClientCmd(client));

        //================================================== Gets =======================================================
        public static IO<ISelectRestaurantResult> GetRestaurant(string name)
            => from restaurant in Database.Query<FindRestaurantQuery, Restaurant>(new FindRestaurantQuery(name))
               from getResult in RestaurantDomain.SelectRestaurant(restaurant)
               let agg = (getResult as SelectRestaurantResult.RestaurantSelected)?.Restaurant
               select getResult;

        public static IO<ISelectMenuResult> GetMenu(String name, int restaurantId) =>
            from menu in Database.Query<GetMenuQuery, Menu>(new GetMenuQuery(name, restaurantId))
            from getResult in RestaurantDomain.SelectMenu(menu)
            let agg = (getResult as MenuSelected)?.MenuAgg
            select getResult;

        public static IO<ISelectMenuItemResult> GetMenuItem(String name, int menuId) =>
            from menuItem in Database.Query<GetMenuItemQuery, MenuItem>(new GetMenuItemQuery(name, menuId))
            from getResult in RestaurantDomain.SelectMenuItem(menuItem)
            let agg = (getResult as MenuItemSelected)?.MenuItemAgg
            select getResult;

        public static IO<ISelectClientResult> GetMenuItem(String name) =>
            from client in Database.Query<GetClientQuery, Client>(new GetClientQuery(name))
            from getResult in RestaurantDomain.SelectClient(client)
            let agg = (getResult as ClientSelected)?.ClientAgg
            select getResult;

        //===========================================Multiple Select Gets =============================================

        public static IO<ICollection<Menu>> GetAllMenus(int restaurantId) =>
            from getAllMenus in Database.Query<GetAllMenusQuery, ICollection<Menu>>(new GetAllMenusQuery(restaurantId))
            select getAllMenus;

        public static IO<ICollection<MenuItem>> GetAllMenuItems(int menuId) =>
            from getAllMenuItems in Database.Query<GetAllMenuItemsQuery, ICollection<MenuItem>>(new GetAllMenuItemsQuery(menuId))
            select getAllMenuItems;

        public static IO<ICollection<Order>> GetAllOrdersItems(int restaurantId) =>
            from getAllOrders in Database.Query<GetAllOrdersQuery, ICollection<Order>>(new GetAllOrdersQuery(restaurantId))
            select getAllOrders;

        // ============================================== Deletes ======================================================

        //============================================= Updates ========================================================

        //============================================= Others ===========================================================

        public static IO<IAddToCartResult> AddItemsToCart(ClientAgg clientAgg, List<CartItem> items) =>
            NewIO<AddToCartOp.AddToCartCmd, IAddToCartResult>(new AddToCartOp.AddToCartCmd(clientAgg, items));

        public static IO<IChangeQuantityResult> ChangeQuantity(ClientAgg clientAgg, CartItem cartItem, uint quantity) =>
            NewIO<ChangeQuantityOp.ChangeQuantityCmd, IChangeQuantityResult>(new ChangeQuantityOp.ChangeQuantityCmd(clientAgg, cartItem, quantity));

        public static IO<ISetOrderStatusResult> SetOrderStatus(ClientAgg clientAgg, CartStatus newStatus) =>
            NewIO<SetOrderStatusOp.SetOrderStatusCmd, ISetOrderStatusResult>(new SetOrderStatusOp.SetOrderStatusCmd(clientAgg, newStatus));

        public static IO<IGetPaymentStatusResult> GetPaymentStatus(ClientAgg clientAgg) =>
            NewIO<GetPaymentStatusOp.GetPaymentStatusCmd, IGetPaymentStatusResult>(new GetPaymentStatusOp.GetPaymentStatusCmd(clientAgg));

        public static IO<IRequestPaymentResult> RequestPayment(ClientAgg clientAgg) =>
            NewIO<RequestPaymentOp.RequestPaymentCmd, IRequestPaymentResult>(new RequestPaymentOp.RequestPaymentCmd(clientAgg));
    }
}