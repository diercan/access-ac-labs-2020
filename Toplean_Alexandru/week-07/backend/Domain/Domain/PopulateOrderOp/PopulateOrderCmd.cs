using Domain.Models;
using Infra.Free;
using Infrastructure.Free;
using Persistence.EfCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Domain.PopulateOrderOp
{
    public class PopulateOrderCmd
    {
        public Restaurant Restaurant { get; }
        public ICollection<Order> Orders { get; set; }
        public Func<int, IO<ICollection<Order>>> GetAllOrders { get; set; }
        public Func<int, IO<ICollection<OrderItems>>> GetAllOrderItems { get; set; }

        public LiveInterpreterAsync interpreter { get; }

        public PopulateOrderCmd(Restaurant restaurant, ICollection<Order> orders, Func<int, IO<ICollection<Order>>> getAllOrders, Func<int, IO<ICollection<OrderItems>>> getAllOrderItems, LiveInterpreterAsync interpreter)
        {
            Restaurant = restaurant;
            Orders = orders;
            GetAllOrderItems = getAllOrderItems;
            GetAllOrders = getAllOrders;
            this.interpreter = interpreter;
        }
    }
}