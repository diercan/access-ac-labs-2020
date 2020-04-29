using Persistence.EfCore;
using System;
using System.Text;

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
