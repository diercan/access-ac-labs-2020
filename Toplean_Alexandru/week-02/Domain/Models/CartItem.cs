using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Models
{
    public class CartItem : Cart
    {
        public uint Quantity { get; set; }
        public MenuItem MenuItem { get; }

        public CartItem(MenuItem item, uint quantity)
        {
            MenuItem = item;
            Quantity = quantity;
        }
    }
}