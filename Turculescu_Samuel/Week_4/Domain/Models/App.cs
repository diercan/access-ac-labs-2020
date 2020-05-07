using System;
using System.Collections.Generic;
using System.Text;
using Persistence.EfCore;

namespace Domain.Models
{
    public static class App
    {
        public static List<Client> ClientsList { get; set; } = new List<Client>();  // List with users of OrderAndPay App
        public static List<Restaurant> RestaurantsList { get; set; } = new List<Restaurant>();  // List with the restaurants that use OrderAndPay App 

    }
}
