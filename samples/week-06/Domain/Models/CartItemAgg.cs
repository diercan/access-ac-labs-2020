using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Domain.Models
{
    public class CartItemAgg
    {
        public uint Quantity { get; set; }

        public MenuItemAgg MenuItem { get; }

        public CartItemAgg(MenuItemAgg item, uint quantity)
        {
            MenuItem = item;
            Quantity = quantity;
        }
    }
}