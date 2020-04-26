using Domain.Domain.GetOp;
using Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Domain.GetRestaurantOp
{
    public class GetRestaurantCmd : GetCmd<Restaurant>
    {
        public GetRestaurantCmd(List<Restaurant> items, Predicate<Restaurant> expression) : base(items, expression)
        {
        }
    }
}
