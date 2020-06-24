using CSharp.Choices.Attributes;
using Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Domain.PopulateRestaurantOp
{
    [AsChoice]
    public static partial class PopulateRestaurantResult
    {
        public interface IPopulateRestaurantResult { }

        public class RestaurantPopulated : IPopulateRestaurantResult
        {
            public RestaurantAgg RestaurantAgg { get; }

            public RestaurantPopulated(RestaurantAgg restaurantAgg)
            {
                RestaurantAgg = restaurantAgg;
            }
        }

        public class RestaurantNotPopulated : IPopulateRestaurantResult
        {
            public String Reason { get; }

            public RestaurantNotPopulated(String reason)
            {
                Reason = reason;
            }
        }
    }
}