using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Domain.Models
{
    public class CartItem
    {
        [Required(ErrorMessage = "Quantity field is required")]
        [Range(0, int.MaxValue, ErrorMessage = "Quantity must be a positive number")]
        public uint Quantity { get; set; }

        [Required(ErrorMessage = "Menu Item field is required!")]
        public MenuItem MenuItem { get; }

        public CartItem(MenuItem item, uint quantity)
        {
            MenuItem = item;
            Quantity = quantity;
        }
    }
}