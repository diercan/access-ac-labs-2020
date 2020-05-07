using Persistence.EfCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Domain.PersistRestaurant
{
    public class PersistRestaurantCmd
    {
        public Restaurant DomainRestaurant { get; }
        public PersistRestaurantCmd(Restaurant domainRestaurant)
        {
            DomainRestaurant = domainRestaurant;
        }
    }
}
