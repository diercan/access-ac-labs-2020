using CSharp.Choices.Attributes;
using Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Domain.AddToCartOp
{
    [AsChoice]
    public static partial class AddMenuItemToCartResult
    {
        public interface IAddMenuItemToCartResult { };

        public class MenuItemAddedToCart : IAddMenuItemToCartResult
        {
            public MenuItem MenuItem;
            public Client Client;
            public ushort Quantity;
            public MenuItemAddedToCart(MenuItem menuItem, Client client, ushort quantity)
            {
                MenuItem = menuItem;
                Client = client;
                Quantity = quantity;
            }
        }
        public class MenuItemNotAddedToCart : IAddMenuItemToCartResult
        {
            public string Reason;
            public MenuItemNotAddedToCart(string reason)
            {
                Reason = reason;
            }
        }

    }
}
