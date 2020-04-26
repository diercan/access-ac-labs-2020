using Domain.Domain.GetOp;
using Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;
using static Domain.Domain.GetOp.GetResult;

namespace Domain.Domain.GetRestaurantOp
{
    public class GetRestaurantResult
    {
        public interface IGetRestaurantResult : IGetResult<Restaurant> { }

        public class RestaurantFound : Found<Restaurant>
        {
            public RestaurantFound(List<Restaurant> items) : base(items)
            {
            }
        }

        public class RestaurantNotFound : NotFound<Restaurant>
        {
            public RestaurantNotFound(NotFoundReason reason) : base(reason)
            {
            }
        }
    }
}
