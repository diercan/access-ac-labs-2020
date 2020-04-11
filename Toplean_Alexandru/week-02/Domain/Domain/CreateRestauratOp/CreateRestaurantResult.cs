using System;
using System.Collections.Generic;
using System.Text;
using CSharp.Choices.Attributes;
using Domain.Models;
using System.Threading.Tasks;
using static Domain.Models.Restaurant;

namespace Domain.Domain.CreateRestauratOp
{
    [AsChoice]
    public static partial class CreateRestaurantResult
    {
        public interface ICreateRestaurantResult { }

        public class RestaurantCreated : ICreateRestaurantResult
        {
            public Restaurant Restaurant { get; }

            public RestaurantCreated(Restaurant restaurant)
            {
                Restaurant = restaurant;
            }
        }

        public class RestaurantNotCreated : ICreateRestaurantResult
        {
            public String Reason { get; }

            public RestaurantNotCreated(String reason)
            {
                Reason = reason;
            }
        }
    }
}