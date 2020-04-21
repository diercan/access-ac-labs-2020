using System;
using System.Collections.Generic;
using System.Text;
using CSharp.Choices.Attributes;
using Domain.Models;
using System.Threading.Tasks;

namespace Domain.Domain.ClientRoles.GetRestaurantOp
{
    [AsChoice]
    public static partial class GetRestaurantResult
    {
        public interface IGetRestaurantResult { }

        public class RestaurantGotten : IGetRestaurantResult
        {
            public Restaurant Restaurant { get; }
            public RestaurantGotten(Restaurant restaurant)
            {
                Restaurant = restaurant;
            }
        }

        public class RestaurantNotGotten : IGetRestaurantResult
        {
            public string Reason { get; }
            public RestaurantNotGotten(string reason)
            {
                Reason = reason;
            }
        }
    }
}
