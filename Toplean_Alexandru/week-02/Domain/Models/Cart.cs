using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Models
{
    public class Cart
    {
        public enum PaymentStatus
        {
            Uninitialized,
            PaymentRequested,
            WaitingForClientPayment,
            PaymentSubmitted,
            PaymentAccepted
        }

        public enum CartStatus
        {
            CartCreated,
            BuildingCart,
            CartSubmitted,
            PendingOrder,
            OrderInProgress,
            OrderFinished
        };

        public List<CartItem> CartItems { get; set; } = new List<CartItem>();
        public CartStatus Status { get; set; }
        public PaymentStatus Payment { get; set; }

        public Cart()
        {
            Status = CartStatus.CartCreated;
            Payment = PaymentStatus.Uninitialized;
        }

        public int GetNumberOfItems() => CartItems.Count;
    }
}