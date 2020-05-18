using Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Domain.CreateOrderOp
{
    public class CreateOrderCmd
    {
        public Restaurant Restaurant { get; }
        public Client Client { get; }
        public CreateOrderCmd(Restaurant restaurant, Client client)
        {
            Restaurant = restaurant;
            Client = client;
        }
    }
}
