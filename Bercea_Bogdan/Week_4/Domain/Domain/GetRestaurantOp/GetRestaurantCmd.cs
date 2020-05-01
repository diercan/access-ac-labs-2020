using System;
using System.Text;
using Persistence.EfCore;

namespace Domain.Domain.GetRestaurantOp
{
    public class GetRestaurantCmd
    {
        public Restaurant Restaurant { get; }

        public GetRestaurantCmd(Restaurant restaurant)
        {
            Restaurant = restaurant;
        }
    }
}
