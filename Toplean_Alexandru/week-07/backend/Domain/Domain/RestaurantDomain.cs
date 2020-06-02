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
using Infrastructure.Free;
using LanguageExt;
using System.Threading.Tasks;
using static Domain.Domain.UpdateEntityOp.UpdateEntityResult;

using Domain.Entities;
using Domain.Domain.UpdateEntityOp;
using static Domain.Domain.UpdateOrderOp.UpdateOrderResult;
using Domain.Domain.UpdateOrderOp;
using static Domain.Domain.UpdateMenuOp.UpdateMenuResult;
using Domain.Domain.UpdateMenuOp;
using static Domain.Domain.PopulateRestaurantOp.PopulateRestaurantResult;
using static Domain.Domain.CreateOrderItemOp.CreateOrderItemResult;
using Domain.Domain.CreateOrderItemOp;
using static Domain.Domain.DeleteOrderOp.DeleteOrderResult;
using static Domain.Domain.SelectOrderOp.SelectOrderResult;
using Domain.Domain.SelectOrderOp;
using Domain.Domain.UpdateClientOp;
using static Domain.Domain.UpdateClientOp.UpdateClientResult;
using static Domain.Domain.UpdateMenuItemOp.UpdateMenuItemResult;
using Domain.Domain.UpdateMenuItemOp;
using static Domain.Domain.DeleteMenuItemOp.DeleteMenuItemResult;
using static Domain.Domain.PopulateOrderOp.PopulateOrderResult;

namespace Domain.Domain
{
    public static class RestaurantDomain
    {
        //========================================== Creates =========================================================
        //public static IO<ICreateRestaurantResult> CreateRestaurant(string name) =>
        //    NewIO<CreateRestaurantCmd, ICreateRestaurantResult>(new CreateRestaurantCmd(name));

        public static IO<ICreateRestaurantResult> CreateRestaurant(Restaurant restaurant) =>
            NewIO<CreateRestaurantCmd, ICreateRestaurantResult>(new CreateRestaurantCmd(restaurant));

        //public static IO<ICreateMenuResult> CreateMenu(int id, string name, String menuType, bool isVisible, String hours, Restaurant restaurant) =>
        //   NewIO<CreateMenuCmd, ICreateMenuResult>(new CreateMenuCmd(id, name, menuType, isVisible, hours, restaurant));

        public static IO<ICreateMenuResult> CreateMenu(Menu menu, Restaurant restaurant) =>
           NewIO<CreateMenuCmd, ICreateMenuResult>(new CreateMenuCmd(menu, restaurant));

        public static IO<ICreateMenuItemResult> CreateMenuItem(Menu menu, MenuItem menuItem) =>
           NewIO<CreateMenuItemCmd, ICreateMenuItemResult>(new CreateMenuItemCmd(menu, menuItem));

        public static IO<ICreateClientResult> CreateClient(Client client) =>
          NewIO<CreateClientCmd, ICreateClientResult>(new CreateClientCmd(client));

        public static IO<ICreateOrderResult> CreateOrder(Order order) =>
          NewIO<CreateOrderCmd, ICreateOrderResult>(new CreateOrderCmd(order));

        public static IO<ICreateOrderItemResult> CreateOrderItem(OrderItems orderItem) =>
            NewIO<CreateOrderItemCmd, ICreateOrderItemResult>(new CreateOrderItemCmd(orderItem));

        //=============================================== Creates and persists ============================================
        public static IO<CreateRestaurantResult.ICreateRestaurantResult> CreateAndPersistRestaurant(Restaurant restaurant) =>
            from restaurantCreated in RestaurantDomain.CreateRestaurant(restaurant)
            let restaurantAgg = (restaurantCreated as RestaurantCreated)?.RestaurantAgg
            from dbContext in Database.AddOrUpdateEntity(restaurantAgg.Restaurant)
            select restaurantCreated;

        //public static IO<ICreateMenuResult> CreateAndPersistMenu(int id, string name, String menuType, bool isVisible, String hours, Restaurant restaurant) =>
        //   from menuCreated in RestaurantDomain.CreateMenu(id, name, menuType, isVisible, hours, restaurant)
        public static IO<ICreateMenuResult> CreateAndPersistMenu(Menu menu, Restaurant restaurant) =>
           from menuCreated in RestaurantDomain.CreateMenu(menu, restaurant)
           let menuAgg = (menuCreated as MenuCreated)?.Menu
           from dbContext in Database.AddOrUpdateEntity(menuAgg.Menu)
           select menuCreated;

        public static IO<ICreateMenuItemResult> CreateAndPersistMenuItem(Menu menu, MenuItem menuItem) =>
           from menuItemCreated in RestaurantDomain.CreateMenuItem(menu, menuItem)
           let menuItemAgg = (menuItemCreated as MenuItemCreated)?.MenuItemAgg
           from dbContext in Database.AddOrUpdateEntity(menuItemAgg.MenuItem)
           select menuItemCreated;

        public static IO<ICreateClientResult> CreateAndPersistClient(Client client) =>
           from clientCreated in RestaurantDomain.CreateClient(client)
           let clientAgg = (clientCreated as ClientCreated)?.ClientAgg
           from dbContext in Database.AddOrUpdateEntity(clientAgg.Client)
           select clientCreated;

        public static IO<ICreateOrderResult> CreateAndPersistOrder(Order order) =>
           from orderCreated in RestaurantDomain.CreateOrder(order)
           let orderAgg = (orderCreated as OrderCreated)?.OrderAgg
           from dbContext in Database.AddOrUpdateEntity(orderAgg.Order)
           select orderCreated;

        public static IO<ICreateOrderItemResult> CreateAndPersistOrderItem(OrderItems orderItem) =>
            from createOrderItem in CreateOrderItem(orderItem)
            from db in Database.AddOrUpdateEntity(orderItem)
            select createOrderItem;

        // ===================================================== Selects ================================================
        public static IO<ISelectRestaurantResult> SelectRestaurant(Restaurant restaurant) =>
           NewIO<SelectRestaurantCmd, ISelectRestaurantResult>(new SelectRestaurantCmd(restaurant));

        public static IO<ISelectMenuResult> SelectMenu(Menu menu) =>
            NewIO<SelectMenuCmd, ISelectMenuResult>(new SelectMenuCmd(menu));

        public static IO<ISelectMenuItemResult> SelectMenuItem(MenuItem menuItem) =>
            NewIO<SelectMenuItemCmd, ISelectMenuItemResult>(new SelectMenuItemCmd(menuItem));

        public static IO<ISelectClientResult> SelectClient(Client client) =>
            NewIO<SelectClientCmd, ISelectClientResult>(new SelectClientCmd(client));

        public static IO<ISelectOrderResult> SelectOrder(Order order) =>
            NewIO<SelectOrderCmd, ISelectOrderResult>(new SelectOrderCmd(order));

        //================================================== Gets =======================================================
        public static IO<ISelectRestaurantResult> GetRestaurant(string name)
            => from restaurant in Database.Query<FindRestaurantQuery, Restaurant>(new FindRestaurantQuery(name))
               from getResult in RestaurantDomain.SelectRestaurant(restaurant)
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

        public static IO<ISelectMenuItemResult> GetMenuItemById(int menuItemId) =>
            from menuItem in Database.Query<GetMenuItemByIdQuery, MenuItem>(new GetMenuItemByIdQuery(menuItemId))
            from getResult in RestaurantDomain.SelectMenuItem(menuItem)
            let agg = (getResult as MenuItemSelected)?.MenuItemAgg
            select getResult;

        public static IO<ISelectClientResult> GetClient(String name, String password = null) =>
            from client in Database.Query<GetClientQuery, Client>(new GetClientQuery(name, password))
            from getResult in RestaurantDomain.SelectClient(client)
            let agg = (getResult as ClientSelected)?.Client
            select getResult;

        public static IO<ISelectOrderResult> GetOrder(int restaurantId) =>
           from selectOrder in Database.Query<GetOrderQuery, Order>(new GetOrderQuery(restaurantId))
           from getOrder in RestaurantDomain.SelectOrder(selectOrder)
           let order = (getOrder as OrderSelected)?.OrderAgg
           select getOrder;

        //===========================================Multiple Select Gets =============================================

        public static IO<ICollection<Order>> GetAllOrders(int restaurantId) =>
           from getAllOrders in Database.Query<GetAllOrdersQuery, ICollection<Order>>(new GetAllOrdersQuery(restaurantId))
           select getAllOrders;

        public static IO<ICollection<Order>> GetAllClientOrders(int clientId) =>
            from getAllOrders in Database.Query<GetAllClientOrdersQuery, ICollection<Order>>(new GetAllClientOrdersQuery(clientId))
            select getAllOrders;

        public static IO<ICollection<Menu>> GetAllMenus(int restaurantId) =>
            from getAllMenus in Database.Query<GetAllMenusQuery, ICollection<Menu>>(new GetAllMenusQuery(restaurantId))
            select getAllMenus;

        public static IO<ICollection<MenuItem>> GetAllMenuItems(int menuId) =>
            from getAllMenuItems in Database.Query<GetAllMenuItemsQuery, ICollection<MenuItem>>(new GetAllMenuItemsQuery(menuId))
            select getAllMenuItems;

        public static IO<ICollection<OrderItems>> GetAllOrderItems(int orderId) =>
            from getAllOrderItems in Database.Query<GetAllOrderItemsQuery, ICollection<OrderItems>>(new GetAllOrderItemsQuery(orderId))
            select getAllOrderItems;

        public static IO<ICollection<MenuItem>> GetAllMenuItemsFromIdList(int[] orderIds) =>
            from getAllMenuItems in Database.Query<GetMenuItemsFromIdList, ICollection<MenuItem>>(new GetMenuItemsFromIdList(orderIds))
            select getAllMenuItems;

        public static IO<ICollection<Restaurant>> GetAllRestaurants() =>
            from getAllRestaurants in Database.Query<GetAllRestaurantsQuery, ICollection<Restaurant>>(new GetAllRestaurantsQuery())
            select getAllRestaurants;

        // ============================================== Deletes ======================================================

        public static IO<IDeleteOrderResult> DeleteOrder(Order order) =>
            NewIO<DeleteOrderOp.DeleteOrderCmd, IDeleteOrderResult>(new DeleteOrderOp.DeleteOrderCmd(order));

        public static IO<IDeleteOrderResult> DeleteOrderFromDB(int orderID) =>
            from getOrder in RestaurantDomain.GetOrder(orderID)
            let order = (getOrder as OrderSelected)?.OrderAgg.Order
            from deleteOrder in DeleteOrder(order)
            let orderToDelete = (deleteOrder as OrderDeleted)?.Order
            from db in Database.DeleteEntity(orderToDelete)
            select deleteOrder;

        public static IO<IDeleteMenuItemResult> DeleteMenuItem(MenuItem menuItem) =>
            NewIO<DeleteMenuItemOp.DeleteMenuItemCmd, IDeleteMenuItemResult>(new DeleteMenuItemOp.DeleteMenuItemCmd(menuItem));

        public static IO<IDeleteMenuItemResult> DeleteMenuItemFromDB(string menuName, int menuID) =>
            from getMenuItem in RestaurantDomain.GetMenuItem(menuName, menuID)
            let menuItem = (getMenuItem as MenuItemSelected)?.MenuItemAgg.MenuItem
            from deleteMenuItem in DeleteMenuItem(menuItem)
            let menuItemToDelete = (deleteMenuItem as MenuItemDeleted)?.MenuItem
            from db in Database.DeleteEntity(menuItemToDelete)
            select deleteMenuItem;

        //============================================= Updates ========================================================

        public static IO<IUpdateOrderResult> UpdateOrder(Order order) =>
            NewIO<UpdateOrderCmd, IUpdateOrderResult>(new UpdateOrderCmd(order));

        public static IO<IUpdateMenuResult> UpdateMenu(Menu menu) =>
            NewIO<UpdateMenuCmd, IUpdateMenuResult>(new UpdateMenuCmd(menu));

        public static IO<IUpdateClientResult> UpdateClient(Client client) =>
            NewIO<UpdateClientCmd, IUpdateClientResult>(new UpdateClientCmd(client));

        public static IO<IUpdateMenuItemResult> UpdateMenuItem(MenuItem item) =>
            NewIO<UpdateMenuItemCmd, IUpdateMenuItemResult>(new UpdateMenuItemCmd(item));

        //============================================= Update And Persist ========================================================

        public static IO<IUpdateOrderResult> UpdateAndPersistOrder(Order order) =>
            from updateOrder in UpdateOrder(order)
            from db in Database.AddOrUpdateEntity(order)
            select updateOrder;

        public static IO<IUpdateMenuResult> UpdateAndPersistMenu(Menu menu) =>
            from updateMenu in UpdateMenu(menu)
            from db in Database.AddOrUpdateEntity(menu)
            select updateMenu;

        public static IO<IUpdateClientResult> UpdateAndPersistClient(Client client) =>
            from updateClient in UpdateClient(client)
            from db in Database.AddOrUpdateEntity(client)
            select updateClient;

        public static IO<IUpdateMenuItemResult> UpdateAndPersistMenuItem(MenuItem item) =>
            from updateMenuItem in UpdateMenuItem(item)
            from db in Database.UpdateEntity(item)
            select updateMenuItem;

        //============================================= Others ===========================================================

        public static IO<IAddToCartResult> AddItemsToCart(ClientAgg clientAgg, List<CartItem> items) =>
            NewIO<AddToCartOp.AddToCartCmd, IAddToCartResult>(new AddToCartOp.AddToCartCmd(clientAgg, items));

        public static IO<IChangeQuantityResult> ChangeQuantity(ClientAgg clientAgg, CartItem cartItem, uint quantity) =>
            NewIO<ChangeQuantityOp.ChangeQuantityCmd, IChangeQuantityResult>(new ChangeQuantityOp.ChangeQuantityCmd(clientAgg, cartItem, quantity));

        public static IO<ISetOrderStatusResult> SetOrderStatus(ClientAgg clientAgg, CartStatus newStatus) =>
            NewIO<SetOrderStatusOp.SetOrderStatusCmd, ISetOrderStatusResult>(new SetOrderStatusOp.SetOrderStatusCmd(clientAgg, newStatus));

        public static IO<IGetPaymentStatusResult> GetPaymentStatus(Order order) =>
            NewIO<GetPaymentStatusOp.GetPaymentStatusCmd, IGetPaymentStatusResult>(new GetPaymentStatusOp.GetPaymentStatusCmd(order));

        public static IO<IRequestPaymentResult> RequestPayment(ClientAgg clientAgg) =>
            NewIO<RequestPaymentOp.RequestPaymentCmd, IRequestPaymentResult>(new RequestPaymentOp.RequestPaymentCmd(clientAgg));

        // Populates the RestaurantAgg model with the data from two functions, using a LiveAsyncInterpreter.
        // This function will firstly populate the ICollection<Menu> Menus by calling GetAllMenus, with all the menus from the database that have the restaurant's id
        // After the ICollection<Menu> will be filled, for each entity it will call the GetAllMenuItems function to populate the menu

        public static IO<IPopulateRestaurantResult> PopulateRestaurant(RestaurantAgg restaurantAgg, Func<int, IO<ICollection<Menu>>> getAllMenus, Func<int, IO<ICollection<MenuItem>>> getAllMenuItems, LiveInterpreterAsync interpreter) =>
            NewIO<PopulateRestaurantOp.PopulateRestaurantCmd, IPopulateRestaurantResult>(new PopulateRestaurantOp.PopulateRestaurantCmd(restaurantAgg, getAllMenus, getAllMenuItems, interpreter));

        public static IO<IPopulateOrderResult> PopulateOrder(Restaurant restaurant, ICollection<Order> orders, Func<int, IO<ICollection<Order>>> getAllOrders, Func<int, IO<ICollection<OrderItems>>> getAllOrderItems, LiveInterpreterAsync interpreter) =>
                    NewIO<PopulateOrderOp.PopulateOrderCmd, IPopulateOrderResult>(new PopulateOrderOp.PopulateOrderCmd(restaurant, orders, getAllOrders, getAllOrderItems, interpreter));

        [Obsolete("Please use the IO<> PopulateRestaurant Function! This class is deprecated")]
        public static async Task PopulateRestaurantModel(RestaurantAgg restaurantAgg, Func<int, IO<ICollection<Menu>>> getAllMenus, Func<int, IO<ICollection<MenuItem>>> getAllMenuItems, LiveInterpreterAsync interpreter)
        {
            var expression = from allMenus in getAllMenus(restaurantAgg.Restaurant.Id)
                             select allMenus;

            var result = await interpreter.Interpret(expression, Unit.Default);

            restaurantAgg.Menus = result;
            foreach (var menu in restaurantAgg.Menus)
            {
                var expressionMenuItem = from allMenuItems in getAllMenuItems(menu.Id)
                                         select allMenuItems;

                var resultMenuItem = await interpreter.Interpret(expressionMenuItem, Unit.Default);
                menu.MenuItem = resultMenuItem;
            }
        }
    }
}