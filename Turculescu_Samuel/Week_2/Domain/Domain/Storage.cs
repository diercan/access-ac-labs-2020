using Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Domain
{
    public static class Storage
    {
        public static List<Client> ClientsList { get; set; } = new List<Client>();  // List with users of OrderAndPay App
        public static List<Restaurant> RestaurantsList { get; set; } = new List<Restaurant>();  // List with the restaurants that use OrderAndPay App 

    }
}
