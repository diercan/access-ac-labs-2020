using System;
using System.Collections.Generic;

namespace Persistence.EfCore
{
    public partial class Order
    {
        public Order()
        {
        }

        public Order(int clientID, int restauranID, int tableNumber, String itemNames, String itemQuantities, String itemComments, double totalPrice, String status, String paymentStatus)
        {
            ClientId = clientID;
            RestaurantId = restauranID;
            TableNumber = tableNumber;
            ItemNames = itemNames;
            ItemQuantities = itemQuantities;
            ItemComments = itemComments;
            TotalPrice = totalPrice;
            Status = status;
            PaymentStatus = paymentStatus;
        }

        public int Id { get; set; }
        public int ClientId { get; set; }
        public int RestaurantId { get; set; }
        public int TableNumber { get; set; }
        public string ItemNames { get; set; }
        public string ItemQuantities { get; set; }
        public string ItemComments { get; set; }
        public double TotalPrice { get; set; }
        public string Status { get; set; }
        public string PaymentStatus { get; set; }

        public virtual Client Client { get; set; }
        public virtual Restaurant Restaurant { get; set; }
    }
}