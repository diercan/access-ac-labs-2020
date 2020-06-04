using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Models
{
    public class Cart
    {
        public List<CartItem> CartItems { get; set; }

        public Cart()
        {
            CartItems = new List<CartItem>();
        }

        /*public double GetTotalPrice()       // get Total Price from Cart 
        {
            double totalPrice = 0;
            List<CartItem>.Enumerator e = CartItems.GetEnumerator();            

            while (e.MoveNext())
            {
                totalPrice += e.Current.Price;
            }

            return totalPrice;
        }*/
    }
}
