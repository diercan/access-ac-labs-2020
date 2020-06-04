using System;
using System.Collections.Generic;
using System.Text;
using CSharp.Choices.Attributes;
using Domain.Models;
using System.Threading.Tasks;
using Persistence.EfCore;

namespace Domain.Domain.GetRestaurantsOp
{
    [AsChoice]
    public static partial class GetRestaurantsResult
    {
        public interface IGetRestaurantsResult { }

        public class RestaurantsFound : IGetRestaurantsResult
        {
            public List<Restaurant> Restaurants { get; }

            public RestaurantsFound(List<Restaurant> restaurants)
            {
                Restaurants = restaurants;
            }
        }

        public class RestaurantsNotFound : IGetRestaurantsResult
        {
            public string Reason { get; }

            public RestaurantsNotFound(string reason)
            {
                //Console.WriteLine(reason);
                Reason = reason;
            }
        }
    }
}
