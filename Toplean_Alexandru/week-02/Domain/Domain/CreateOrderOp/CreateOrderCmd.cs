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

        public (bool, String) IsValid()
        {
            try
            {
                if (IncorectInputType(OrderID, typeof(int)))
                    return (false, "Order id field should be type of int");

                if (Restaurant == null)
                    return (false, "No restaurant provided. Restaurant is null");

                return (true, "None");
            }
            catch (Exception exp)
            {
                return (false, exp.ToString());
            }
        }

        public bool IncorectInputType(dynamic value, Type expectedType) => value.GetType() != expectedType ? true : false;  // Checks if a variable is the correct type
    }
}