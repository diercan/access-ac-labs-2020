using Persistence.EfCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Models
{
    public class ClientAgg
    {      
        public Client Client { get; set; }


        public Cart Cart { get; set; }  // Each Client has a Cart with CartItems
        //public Order Order { get; set; }

        public List<Order> OrdersPlaced { get; } = new List<Order>();


        public ClientAgg(Client client)
        {
            Client = client;
        }
    }
}
