using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Models
{
    public class Order
    {
        public enum OrderErrorCodes
        {
            UnknownError,
            InexistentTable,
            None,
            IncorrectType,
            NullRestaurant
        }

        public int OrderID { get; }
        public int TableNumber { get; }

        public List<MenuItem> Items { get; }

        public String Waiter { get; }

        public float Price { get; }

        public Order(int id, int tableNumber, List<MenuItem> items, String waiter, float price)
        {
            OrderID = id;
            TableNumber = tableNumber;
            Items = items;
            Waiter = waiter;
            Price = price;
        }
    }
}