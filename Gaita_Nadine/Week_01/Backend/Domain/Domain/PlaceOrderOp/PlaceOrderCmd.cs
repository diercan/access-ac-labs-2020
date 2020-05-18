using Domain.Models;
using Infrastructure.Free;
using LanguageExt;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Domain.PlaceOrder
{
    public class PlaceOrderCmd
    {
        public Order Order { get; }
        public PlaceOrderCmd(Order order)
        {
            Order = order;
        }
    }
}
