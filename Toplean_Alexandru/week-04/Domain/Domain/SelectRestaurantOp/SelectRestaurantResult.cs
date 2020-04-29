using CSharp.Choices.Attributes;
using Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Persistence.EfCore;

namespace Domain.Domain.SelectRestaurantOp
{
    [AsChoice]
    public static partial class SelectRestaurantResult
    {
        public interface ISelectRestaurantResult { }

        public class RestaurantSelected : ISelectRestaurantResult
        {
            public RestaurantAgg Restaurant { get; }

            public RestaurantSelected(RestaurantAgg restaurant)
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