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
            public Restaurant Restaurant { get; }

            public RestaurantCreated(Restaurant restaurant)
            {
                Restaurant = restaurant;
                Storage.RestaurantsList.Add(Restaurant);    // Add restaurant created in list with all restaurants from OrderAndPayApp
            }
        }

        public class RestaurantNotCreated : ICreateRestaurantResult
        {
            public string Reason { get; }

            public RestaurantNotCreated(string reason)
            {
                Reason = reason;
            }
        }
    }
}
