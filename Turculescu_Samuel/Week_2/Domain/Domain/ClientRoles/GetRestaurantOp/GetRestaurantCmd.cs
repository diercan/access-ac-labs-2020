using System;
using System.Collections.Generic;
using System.Text;
using Domain.Models;

namespace Domain.Domain.ClientRoles.GetRestaurantOp
{
    public struct GetRestaurantCmd
    {
        public Client Client { get; }
        public Restaurant Restaurant { get; }

        public GetRestaurantCmd(Client client, Restaurant restaurant)
        {
            Client = client;
            Restaurant = restaurant;
        }
    }
}
