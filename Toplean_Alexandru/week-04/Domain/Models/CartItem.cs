using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Domain.Models
{
    public class CartItem
    {
        public uint Quantity { get; set; }

        public MenuItemAgg MenuItem { get; }

        public CartItem(MenuItemAgg item, uint quantity)
        {
            MenuItem = item;
            Quantity = quantity;
        }
    }
}