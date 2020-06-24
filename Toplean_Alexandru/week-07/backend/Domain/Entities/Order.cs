using Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace Persistence.EfCore
{
    public partial class Order : IEntity
    {
        public Order()
        {
            OrderItems = new HashSet<OrderItems>();
        }

        public Order(int clientID, int restauranID, int tableNumber, double totalPrice, String status, String paymentStatus, bool completed)
        {
            ClientId = clientID;
            RestaurantId = restauranID;
            TableNumber = tableNumber;
            OrderItems = new HashSet<OrderItems>();
            TotalPrice = totalPrice;
            Status = status;
            PaymentStatus = paymentStatus;
            Completed = completed;
        }

        public int Id { get; set; }
        public int ClientId { get; set; }
        public int RestaurantId { get; set; }

        [Range(0, Int32.MaxValue)]
        public int TableNumber { get; set; }

        [Range(0, double.MaxValue)]
        public double TotalPrice { get; set; }

        public string Status { get; set; }
        public string PaymentStatus { get; set; }
        public bool Completed { get; set; }

        [JsonIgnore]
        [IgnoreDataMember]
        public virtual Client Client { get; set; }

        [JsonIgnore]
        [IgnoreDataMember]
        public virtual Restaurant Restaurant { get; set; }

        public virtual ICollection<OrderItems> OrderItems { get; set; }
    }
}