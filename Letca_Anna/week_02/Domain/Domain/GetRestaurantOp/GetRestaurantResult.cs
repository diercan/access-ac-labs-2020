using System;
using System.Collections.Generic;
using System.Text;
using CSharp.Choices.Attributes;
using Domain.Models;
using System.Threading.Tasks;

namespace Domain.Domain.GetRestaurantOp
{
    [AsChoice]
    public static partial class GetRestaurantResult
    {
        public interface IGetRestaurantResult { }

        public class RestaurantFound : IGetRestaurantResult
        {
            public RestaurantAgg RestaurantAgg { get; }

            public RestaurantFound(RestaurantAgg restaurant)
            {
                RestaurantAgg = restaurant;
            }
        }


        public class RestaurantNotFound : IGetRestaurantResult
        {
            public string Reason { get; }

            public RestaurantNotFound(string reason)
            {
                Console.WriteLine(reason);
                Reason = reason;
            }
        }
    }
}
