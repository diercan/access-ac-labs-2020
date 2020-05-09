using CSharp.Choices.Attributes;
using Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Domain.GetRestaurantOp
{
    [AsChoice]
    public static partial class GetRestaurantResult
    {
        public interface IGetRestaurantResult { }

        public class RestaurantFound : IGetRestaurantResult
        {
            public Restaurant Restaurant { get; }

            public RestaurantFound(Restaurant restaurant)
            {
                Restaurant = restaurant;
            }
        }


        public class RestaurantNotFound : IGetRestaurantResult
        {
            public string Reason { get; }

            public RestaurantNotFound(string reason)
            {
                Reason = reason;
            }
        }
    }
}
