using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Domain.GetRestaurantOp;
using Domain.Domain.GetEmployeeOp;
using Domain.Domain.GetMenuOp;
using Domain.Domain.GetMenusOp;
using Domain.Domain.GetMenuItemsOp;
using Domain.Domain.GetOrdersOp;
using Domain.Domain.GetOrderItemsOp;
using Domain.Domain;
using Infrastructure.Free;
using LanguageExt;
using Microsoft.AspNetCore.Mvc;

namespace OrderAndPay.Web.Controllers
{
    [ApiController]
    [Route("orderandpay/[controller]")]
    public class EmployeeController : ControllerBase
    {
        private readonly LiveInterpreterAsync _interpreter;
                
        public EmployeeController(LiveInterpreterAsync interpreter)
        {
            _interpreter = interpreter;
        }

        [HttpGet("{employeeId}/restaurant/{restaurantName}")]
        public async Task<IActionResult> GetEmployee(string restaurantName, string employeeId)
        {
            var getRestaurantExpr =
              from restaurantResult in RestaurantDomain.GetRestaurant(restaurantName)
              select restaurantResult;
            var restaurant = await _interpreter.Interpret(getRestaurantExpr, Unit.Default);

            var getRestaurant =
              from restaurantResult in RestaurantDomainEx.GetRestaurant(restaurantName)
              select restaurantResult;
            var restaurantAgg = await _interpreter.Interpret(getRestaurant, Unit.Default);

            var getEmployeeExpr =
                from employeeResult in RestaurantDomain.GetEmployee(restaurantAgg.Restaurant.Id, employeeId)
                select employeeResult;
            var employee = await _interpreter.Interpret(getEmployeeExpr, Unit.Default);

            return restaurant.Match(
                found => (IActionResult)Ok(found.Agg.Restaurant),
                notFound => NotFound());
        }

        [HttpGet("{employeeId}/restaurant/{restaurantName}/menus")]
        public async Task<IActionResult> GetMenus(string restaurantName)
        {
            var getRestaurantExpr =
              from restaurantResult in RestaurantDomain.GetRestaurant(restaurantName)
              select restaurantResult;
            var restaurant = await _interpreter.Interpret(getRestaurantExpr, Unit.Default);

            var getRestaurant =
              from restaurantResult in RestaurantDomainEx.GetRestaurant(restaurantName)
              select restaurantResult;
            var restaurantAgg = await _interpreter.Interpret(getRestaurant, Unit.Default);

            /*var getMenus =
                from menusRestaurant in RestaurantDomainEx.GetMenus(restaurantAgg.Restaurant)
                select menusRestaurant;
            var menusList = await _interpreter.Interpret(getMenus, Unit.Default);*/

            var getMenusExpr =
                from menusRestaurant in RestaurantDomain.GetMenus(restaurantAgg.Restaurant)
                select menusRestaurant;
            var menus = await _interpreter.Interpret(getMenusExpr, Unit.Default);

            return restaurant.Match(
            found => (IActionResult)Ok(found.Agg.Restaurant.Menus),
            notFound => NotFound());
        }

        [HttpGet("{employeeId}/restaurant/{restaurantName}/menus/{menuId:int}")]
        public async Task<IActionResult> GetMenuItems(int menuId)
        {
            var getMenuExpr =
                from menuResult in RestaurantDomain.GetMenu(menuId)
                select menuResult;
            var menu = await _interpreter.Interpret(getMenuExpr, Unit.Default);

            var getMenu =
                from menuResult in RestaurantDomainEx.GetMenu(menuId)
                select menuResult;
            var menuAgg = await _interpreter.Interpret(getMenu, Unit.Default);

            var getMenuItemsExpr =
                    from menuItemsResult in RestaurantDomainEx.GetMenuItems(menuAgg.Menu)
                    select menuItemsResult;
            var menuItems = await _interpreter.Interpret(getMenuItemsExpr, Unit.Default);

            return menu.Match(
            found => (IActionResult)Ok(found.Agg.Menu.MenuItems),
            notFound => NotFound());
        }

        [HttpGet("{employeeId}/restaurant/{restaurantName}/orders")]
        public async Task<IActionResult> GetOrders(string restaurantName)
        {
            var getRestaurant =
              from restaurantResult in RestaurantDomainEx.GetRestaurant(restaurantName)
              select restaurantResult;
            var restaurantAgg = await _interpreter.Interpret(getRestaurant, Unit.Default);

            var getOrdersExpr =
                from ordersResult in RestaurantDomain.GetRestaurantOrders(restaurantAgg.Restaurant)
                select ordersResult;
            var orders = await _interpreter.Interpret(getOrdersExpr, Unit.Default);

            return orders.Match(
                found => (IActionResult)Ok(found.Orders),
                notFound => NotFound());
        }

        [HttpGet("{employeeId}/restaurant/{restaurantName}/orders/{orderId:int}")]
        public async Task<IActionResult> GetOrderItems(int orderId)
        {

            var getOrderExpr =
                from orderResult in RestaurantDomainEx.GetOrder(orderId)
                select orderResult;
            var order = await _interpreter.Interpret(getOrderExpr, Unit.Default);

            var getOrderItemsExpr =
                from orderItemsResult in RestaurantDomain.GetOrderItems(order.Order)
                select orderItemsResult;
            var orderItems = await _interpreter.Interpret(getOrderItemsExpr, Unit.Default);

            return orderItems.Match(
                found => (IActionResult)Ok(found.OrderItems),
                notFound => NotFound());
        }
    }
}