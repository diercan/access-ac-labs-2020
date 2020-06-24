using System;
using System.Collections.Generic;
using System.Text;
using CSharp.Choices.Attributes;
using System.Threading.Tasks;
using Persistence.EfCore;

namespace Domain.Domain.GetAllRestaurantsOp
{
    [AsChoice]
    public static partial class GetAllRestaurantsResult
    {
        public interface IGetAllRestaurantsResult { }

        public class RestaurantsFound : IGetAllRestaurantsResult
        {

            public List<Restaurant> Restaurants { get; }

            public RestaurantsFound(List<Restaurant> restaurants)
            {
                Restaurants = restaurants;
            }
        }


        public class RestaurantsNotFound : IGetAllRestaurantsResult
        {
            public string Reason { get; }

            public RestaurantsNotFound(string reason)
            {
                Reason = reason;
            }
        }
    }
}
