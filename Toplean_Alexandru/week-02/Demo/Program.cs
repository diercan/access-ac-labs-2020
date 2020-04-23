using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Domain;
using Domain.Domain.CreateRestauratOp;
using Domain.Domain.SelectRestaurantOp;
using Domain.Models;
using Infrastructure.Free;
using LanguageExt;
using Microsoft.Extensions.DependencyInjection;
using Xunit;
using static Domain.Domain.AddToCartOp.AddToCartResult;
using static Domain.Domain.ChangeQuantityOp.ChangeQuantityResult;
using static Domain.Domain.CreateCartItemOp.CreateCartItemResult;
using static Domain.Domain.CreateClientOp.CreateClientResult;
using static Domain.Domain.CreateEmployeeOp.CreateEmployeeResult;
using static Domain.Domain.CreateMenuItem.CreateMenuItemResult;
using static Domain.Domain.CreateMenuOp.CreateMenuResult;
using static Domain.Domain.CreateOrderOp.CreateOrderResult;
using static Domain.Domain.CreateRestauratOp.CreateRestaurantResult;
using static Domain.Domain.DeleteRestaurantOp.DeleteRestaurantResult;
using static Domain.Domain.GetMenusOp.GetMenusResult;
using static Domain.Domain.GetOrdersOp.GetOrdersResult;
using static Domain.Domain.GetOrderStatus.GetOrderStatusResult;
using static Domain.Domain.GetPaymentStatusOp.GetPaymentStatusResult;
using static Domain.Domain.PlaceOrderOp.PlaceOrderResult;
using static Domain.Domain.RequestPaymentOp.RequestPaymentResult;
using static Domain.Domain.SelectRestaurantOp.SelectRestaurantResult;
using static Domain.Domain.SetMenuAvalabilityOp.SetMenuAvalabilityResult;
using static Domain.Models.Restaurant;

namespace Demo
{
    internal class Program
    {
        private static async Task Main(string[] args)
        {
            var serviceCollection = new ServiceCollection();
            serviceCollection.AddOperations(typeof(Restaurant).Assembly);
            var serviceProvider = serviceCollection.BuildServiceProvider();
            var interpreter = new LiveInterpreterAsync(serviceProvider);
            int option;

            // Menu starts here. 3 choices available in this menu, last one being an exit
            do
            {
                Console.WriteLine("*********************SOME WANNABE MENU********************");
                Console.WriteLine("1. Client");
                Console.WriteLine("2. Employee");
                Console.WriteLine("0. Exit");
                Console.Write("What are you? Please input the menu option number ->");
                // Try catch will be used to prevent an unexpected crash, one of them is failing a parsing funciton. Catching an exception will result with
                // the option = -1 and returning to the menu above while displaying the error message, without removing it with Console.Clear()
                try
                {
                    option = Int32.Parse(Console.ReadLine());
                    Console.Clear();
                    switch (option)
                    {
                        case 1: // Client selected
                            {
                                bool StopFlag = false;
                                // Creating an user menu that will allow an user to create an account, see all the restaurants and select a restaurant(for now)
                                do
                                {
                                    // Client menu, three \n are used to make the text easier to read
                                    Console.WriteLine("\n\n\nHello Client, please chose one of the options below");
                                    Console.WriteLine("1. Create a new account");
                                    Console.WriteLine("2. See all restaurants");
                                    Console.WriteLine("3. Select a restaurant");
                                    Console.WriteLine("0. Exit");
                                    Console.Write("Please pick an option => ");
                                    // Try catch used to prevent invalid inputs from the user(using chars instead of numbers)
                                    try
                                    {
                                        int ClientOption1 = Int32.Parse(Console.ReadLine());
                                        switch (ClientOption1)
                                        {
                                            case 1: // Create a new client
                                                {
                                                    Console.WriteLine("\n\n\n******************** Creating a new Client ********************");
                                                    Console.WriteLine("Please fill the following form");
                                                    Console.Write("Name: "); var name = Console.ReadLine();
                                                    Console.Write("Username: "); var username = Console.ReadLine();
                                                    Console.Write("Password: "); var password = Console.ReadLine();
                                                    Console.Write("Email: "); var email = Console.ReadLine();
                                                    Console.WriteLine("Hang on a second! We are creating your account!");

                                                    var createUserExpr = from createClientResult in RestaurantDomain.CreateClient(name, username, password, email)
                                                                         let client = (createClientResult as ClientCreated)?.Client
                                                                         select createClientResult;

                                                    var createUserResult = await interpreter.Interpret(createUserExpr, Unit.Default);

                                                    var createUserFinalResult = createUserResult.Match(
                                                        created => { Console.WriteLine("User Successfuly Created"); return created; },
                                                        notCreated => { Console.WriteLine($"User was not created for the following reason: {notCreated.Reason}"); return notCreated; }
                                                        );

                                                    break;
                                                }
                                            case 2: // List all the available restaurants
                                                {
                                                    Console.WriteLine(" \n\n\n ****************************** All Available Restaurants****************");
                                                    Console.WriteLine("Here is a list of all restaurants");
                                                    int i = 0;
                                                    foreach (var restaurant in AllHardcodedValues.HarcodedVals.RestaurantList)
                                                    {
                                                        Console.WriteLine($"{i++} -> {restaurant.Name}");
                                                    }
                                                    break;
                                                }
                                            case 3: // Select a restaurant
                                                {
                                                    Console.WriteLine("\n\n\n ************************* Select a restaurant *******************");
                                                    Console.WriteLine("What is the restaurant name?");
                                                    String restaurantName = Console.ReadLine();
                                                    Console.WriteLine("Ok! Got it! Wait a second untill we check if the restaurant exists");
                                                    var selectRestaurantExpr = from selectRestaurantRes in RestaurantDomain.SelectRestaurant(restaurantName)
                                                                               let restaurant = (selectRestaurantRes as RestaurantSelected)?.Restaurant
                                                                               select selectRestaurantRes;

                                                    var selectRestaurantResult = await interpreter.Interpret(selectRestaurantExpr, Unit.Default);
                                                    var selectedRestaurantFinalResult = selectRestaurantResult.Match(

                                                        selected =>
                                                        {
                                                            Console.WriteLine("Restaurant Successfully Selected");
                                                            return selected;
                                                        },
                                                        notSelected =>
                                                        {
                                                            Console.WriteLine($"Unable to select restaurant. Reason: {notSelected.Reason}");
                                                            return notSelected;
                                                        }
                                                        );

                                                    // TODO: Display all menus, select menu (by ID?), view menu and create an order

                                                    break;
                                                }
                                            case 0: // Exit
                                                {
                                                    StopFlag = true;
                                                    break;
                                                }
                                            default: // Invalid case selected
                                                {
                                                    break;
                                                }
                                        }
                                    }
                                    catch // Select Client option Try-Catch
                                    {
                                        Console.WriteLine("Please input a valid menu option number");
                                    }
                                }
                                while (StopFlag != true);
                                break;
                            }

                        case 2: // Employee  selected
                            {
                                break;
                            }
                        case 0: // Exit selected
                            {
                                break;
                            }

                        default: // Invalid case selected
                            {
                                break;
                            }
                    }
                }
                catch (Exception exp) // Select client or employee Try-Catch
                {
                    option = -1;
                    Console.WriteLine("Please input a valid menu option number");
                }
            }
            while (option != 0); // End of the select Client or Employee Do-While

            var expr =
                from restaurantResult in RestaurantDomain.CreateRestaurant("Restaurant")         // Selects A Restaurant
                let restaurant = (restaurantResult as RestaurantCreated)?.Restaurant
                from menuRes in RestaurantDomain.CreateMenu(restaurant, "Chicken", MenuType.Meat, MenuVisibilityTypes.RegularMenu)   // Creates a Menu
                let menu = (menuRes as MenuCreated)?.Menu
                from employeeRes in RestaurantDomain.CreateEmployee("1", 2, "3", "4", -5, Employee.JobRoles.Cashier, "6", restaurant) // Creates an Employee
                let employee = (employeeRes as EmployeeCreated)?.Employee
                from orderRes in RestaurantDomain.CreateOrder(0, 1, null, "waiter", 4F, restaurant) // Creates An Order
                let order = (orderRes as OrderCreated)?.Order
                from addMenuItemRes in RestaurantDomain.CreateMenuItem("McChicken", 20, null, new List<string> { "McChicken", "Cartofi prajiti", "Coca Cola" }, null, menu)  // Creates a Menu Item
                let firstMenuItem = (addMenuItemRes as MenuItemCreated)?.MenuItem
                from addMenuItemRes2 in RestaurantDomain.CreateMenuItem("Cheeseburger", 20, null, new List<string> { "Cheeseburger", "Cartofi prajiti", "Coca Cola" }, null, menu)// Creates a Menu Item
                let secondMenuItem = (addMenuItemRes2 as MenuItemCreated)?.MenuItem
                from deleteRestaurantRes in RestaurantDomain.DeleteRestaurant("KFC")  // Deletes a restaurant
                let dlt = (deleteRestaurantRes as RestaurantDeleted)?.Ok
                from getAllMenus in RestaurantDomain.GetAllMenus(restaurant)    // Gets all the available menus from a restaurant
                let allMenus = (getAllMenus as MenusGot)?.Menus
                from createCartItemRes in RestaurantDomain.CreateCartItem("0", firstMenuItem, 50) // Creates a menu item for sessionID = 0;
                let createCartItem = (createCartItemRes as CartItemCreated)?.CartItem
                from addItemToCart in RestaurantDomain.AddToCart("0", AllHardcodedValues.HarcodedVals.CartItems) // Adds a list of cart items to the cart
                let itemsToCart = (addItemToCart as ItemsAddedToCart)
                from changeItemQuantity in RestaurantDomain.ChangeQuantity("0", AllHardcodedValues.HarcodedVals.CartItems[0], 100)  // Changes quantity of the first item of the hardcoded cart list
                let quantityChanged = (changeItemQuantity as QuantityChanged)
                from placeOrder in RestaurantDomain.PlaceOrder(AllHardcodedValues.HarcodedVals.Clients[0], 700) // Places an order with a 700 tip
                let orderPlaced = (placeOrder as OrderPlaced)
                from getOrderStatus in RestaurantDomain.GetOrderStatus("0")     // Gets the status on session with ID 0 (SessionID will be replaced by a 10 char string)
                let getStatus = (getOrderStatus as OrderGot)?.CartStatus
                from setMenuAvalability in RestaurantDomain.SetMenuAvalability(restaurant, menu, MenuVisibilityTypes.SpecialMenu, "8:00 - 12:00") // Marks the menu as special and display time between 8 - 12
                let menuAvalability = (setMenuAvalability as MenuAvalabilitySet)
                from getAllOrdersRes in RestaurantDomain.GetAllOrders(restaurant) // Gets all the current orders from a restaurant
                let getAllOrders = (getAllOrdersRes as OrdersGot)?.Orders
                from requestPaymentResult in RestaurantDomain.RequestPayment("0") // Requests payment from the client with SessionID = 0;
                let requestPayment = (requestPaymentResult as PaymentRequested)
                from checkPaymentResult in RestaurantDomain.CheckPaymentStatus("0") // Checks the  payment status for the client with SessionID = 0;
                let checkPayment = (checkPaymentResult as PaymentStatusGot)?.Status
                from createClientResult in RestaurantDomain.CreateClient("newname1", "newUsername1", "newpassword1", "newEmail1")
                let clientCreated = (createClientResult as ClientCreated)?.Client
                select restaurantResult;

            var result = await interpreter.Interpret(expr, Unit.Default);

            var finalResult = result.Match(OnRestaurantCreated, OnRestaurantNotCreated);
            //var finalResult = result.Match(OnRestaurantSelected, OnRestaurantNotSelected);

            Console.WriteLine("Hello World!");
        }

        private static ICreateRestaurantResult OnRestaurantNotCreated(RestaurantNotCreated arg)
        {
            Console.WriteLine(arg.Reason);
            return arg;
        }

        private static ICreateRestaurantResult OnRestaurantCreated(RestaurantCreated arg)
        {
            return arg;
        }

        private static ISelectRestaurantResult OnRestaurantSelected(RestaurantSelected arg) => arg;

        private static ISelectRestaurantResult OnRestaurantNotSelected(RestaurantNotSelected arg)
        {
            Console.WriteLine(arg.Reason);
            return arg;
        }

        private static ICreateMenuResult OnMenuCreate(MenuCreated arg) => arg;

        private static ICreateMenuResult OnMenuNotCreate(MenuNotCreated arg)
        {
            Console.WriteLine(arg.Reason);
            return arg;
        }
    }
}