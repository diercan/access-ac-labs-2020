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

        public class GetRestaurantSuccessful : IGetRestaurantResult
        {
            public Restaurant Restaurant { get; }

            public GetRestaurantSuccessful(Restaurant restaurant)
            {
                Restaurant = restaurant;
            }
        }

        public class GetRestaurantNotSuccessful : IGetRestaurantResult
        {
            public string Reason { get; }

            public GetRestaurantNotSuccessful(string reason)
            {
                Reason = reason;
            }
        }
    }
}
