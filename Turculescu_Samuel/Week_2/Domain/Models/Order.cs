using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Models
{
    public enum OrderStatus
    {
        Processing,
        Checked,
        Done
    }
    public enum PaymentStatus
    {
        Processing,
        AwaitingPayment,
        Paid
    }

    public class Order
    {
        public uint OrderId { get; }
        public string ClientId { get; }
        public uint TableNumber { get; }
        public OrderStatus OrderStatus { get; set; }
        public PaymentStatus PaymentStatus { get; set; }
        public uint PreparationTimeInMinutes {get; set;}    // Preparation time for a MenuItem

        public List<CartItem> OrderItems { get; set; } = new List<CartItem>();

        public Order(uint orderId, string clientId, uint tableNumber, OrderStatus orderStatus = OrderStatus.Processing, PaymentStatus paymentStatus = PaymentStatus.Processing)
        {
            OrderId = orderId;
            ClientId = clientId;
            TableNumber = tableNumber;
            OrderStatus = orderStatus;
            PaymentStatus = paymentStatus;
        }
    }
}
