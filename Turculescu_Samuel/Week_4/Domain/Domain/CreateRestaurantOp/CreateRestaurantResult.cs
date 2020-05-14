using System;
using System.Collections.Generic;
using System.Text;
using CSharp.Choices.Attributes;
using Domain.Models;
using System.Threading.Tasks;

namespace Domain.Domain.CreateRestaurantOp
{
    [AsChoice]
    public static partial class CreateRestaurantResult
    {
        public interface ICreateRestaurantResult { }

        public class RestaurantCreated : ICreateRestaurantResult
        {
            public RestaurantAgg Restaurant { get; }

            public RestaurantCreated(RestaurantAgg restaurant)
            {
                Restaurant = restaurant;
            }
        }

        public class RestaurantNotCreated : ICreateRestaurantResult
        {
            public string Reason { get; }
            public RestaurantAgg Restaurant { get; }
            public RestaurantNotCreated(string reason, RestaurantAgg restaurant)
            {
                Reason = reason;
                Restaurant = restaurant;
            }
        }
    }
}
