using Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using static Domain.Domain.CreateMenuOp.CreateMenuResult;
using static Domain.Domain.CreateOrderOp.CreateOrderResult;
using static Domain.Models.Order;

namespace Domain.Domain.CreateOrderOp
{
    public struct CreateOrderCmd
    {
        public int OrderID;
        public int TableNumber;
        public List<MenuItem> Items { get; }

        public String Waiter { get; }

        public float Price { get; }
        public Restaurant Restaurant;

        public CreateOrderCmd(int id, int tableNumber, List<MenuItem> items, String waiter, float price, Restaurant restaurant)
        {
            OrderID = id;
            TableNumber = tableNumber;
            Items = items;
            Waiter = waiter;
            Price = price;
            Restaurant = restaurant;
        }

        public (bool, OrderErrorCodes) IsValid()
        {
            return IncorectInputType(OrderID, typeof(int)) ? (false, OrderErrorCodes.IncorrectType) : // TODO: Continue the checks
                Restaurant == null ? (false, OrderErrorCodes.NullRestaurant) :
                (true, OrderErrorCodes.None);
        }

        public bool IncorectInputType(dynamic value, Type expectedType) => value.GetType() != expectedType ? true : false;  // Checks if a variable is the correct type
    }
}