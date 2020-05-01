using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Domain.Models
{
    public class OrderAgg
    {
        public int OrderID { get; }

        [Required(ErrorMessage = "Table number is required")]
        [Range(0, int.MaxValue, ErrorMessage = "The table number must be a valid positive number")]
        public int TableNumber { get; }

        public CartAgg Cart { get; }

        public String Waiter { get; }

        [Range(0, int.MaxValue, ErrorMessage = "The price cannot be negative")]
        public float Price { get; }

        public OrderAgg(int id, int tableNumber, CartAgg cart, String waiter, float price)
        {
            OrderID = id;
            TableNumber = tableNumber;
            Cart = cart;
            Waiter = waiter;
            Price = price;
        }
    }
}