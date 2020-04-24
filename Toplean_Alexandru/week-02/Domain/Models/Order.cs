using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Domain.Models
{
    public class Order
    {
        public int OrderID { get; }

        [Required(ErrorMessage = "Table number is required")]
        [Range(0, int.MaxValue, ErrorMessage = "The table number must be a valid positive number")]
        public int TableNumber { get; }

        public Cart Cart { get; }

        public String Waiter { get; }

        [Range(0, int.MaxValue, ErrorMessage = "The price cannot be negative")]
        public float Price { get; }

        public Order(int id, int tableNumber, Cart cart, String waiter, float price)
        {
            OrderID = id;
            TableNumber = tableNumber;
            Cart = cart;
            Waiter = waiter;
            Price = price;
        }
    }
}