using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Models
{
    public class Cart
    {
        public List<MenuItem> MenuItems { get; } = new List<MenuItem>();
        public double Price { get; set;} = 0;
        public override string ToString()
        {
            string retVal = string.Empty;
            foreach (MenuItem menuItem in MenuItems)
                retVal += menuItem.ToString();
            retVal += $"subtotal = {Price} lei";
            return retVal;
        }

        public void CalculateSubtotal(MenuItem menuItem)
        {
            Price += menuItem.Price;
        }
    }

}
