using Persistence.EfCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Domain.PersistRestaurant
{
    public static partial class PersistRestaurantResult
    {
        public interface IPersistRestaurantResult { }

        public class RestaurantPersisted : IPersistRestaurantResult
        {
            public Restaurant Persisted { get; }
            public RestaurantPersisted(Restaurant persisted)
            {
                Persisted = persisted;
            }
        }
    }
}
