using CSharp.Choices.Attributes;
using Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;
using static Domain.Models.Restaurant;
using System.Threading.Tasks;

namespace Domain.Domain.SelectRestaurantOp
{
    [AsChoice]
    public static partial class SelectRestaurantResult
    {
        public interface ISelectRestaurantResult { }

        public class RestaurantSelected : ISelectRestaurantResult
        {
            public Restaurant Restaurant { get; }

            public RestaurantSelected(Restaurant restaurant)
            {
                Restaurant = restaurant;
            }
        }

        public class RestaurantNotSelected : ISelectRestaurantResult
        {
            public String Reason { get; }

            public RestaurantNotSelected(String error)
            {
                Reason = error;
            }
        }
    }
}