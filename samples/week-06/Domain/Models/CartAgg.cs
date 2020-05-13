using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Models
{
    public class CartAgg
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

        public List<CartItemAgg> CartItems { get; set; } = new List<CartItemAgg>();
        public CartStatus Status { get; set; }
        public PaymentStatus Payment { get; set; }

        public CartAgg()
        {
            Status = CartStatus.CartCreated;
            Payment = PaymentStatus.Uninitialized;
        }

        public int GetNumberOfItems() => CartItems.Count;
    }
}