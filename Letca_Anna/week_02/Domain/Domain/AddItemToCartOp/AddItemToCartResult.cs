using CSharp.Choices.Attributes;
using Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Domain.AddItemToCartOp
{
    [AsChoice]
    public static partial class AddItemToCartResult
    {
        public interface IAddItemToCartResult { };

        public class ItemAddedToCart: IAddItemToCartResult
        {
            public MenuItem MenuItem;
            public Client Client;
            public ItemAddedToCart(MenuItem menuItem, Client client)
            {
                MenuItem = menuItem;
                Client = client;
                
            }
        }

        public class ItemNotAddedToCart: IAddItemToCartResult
        {
            public string Reason;
            public ItemNotAddedToCart(string reason)
            {
                Console.WriteLine(reason);
                Reason = reason;
            }
        }
    }
}
