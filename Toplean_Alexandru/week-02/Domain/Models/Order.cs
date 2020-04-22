using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
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

        [Required(ErrorMessage = "Table number is required")]
        [Range(0, int.MaxValue, ErrorMessage = "The table number must be a valid positive number")]
        public int TableNumber { get; }

        [Required]
        public List<MenuItem> Items { get; }

        public String Waiter { get; }

        [Range(0, int.MaxValue, ErrorMessage = "The price cannot be negative")]
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