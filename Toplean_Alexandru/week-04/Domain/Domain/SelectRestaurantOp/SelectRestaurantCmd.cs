using Persistence.EfCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Domain.SelectRestaurantOp
{
    public class SelectRestaurantCmd
    {
        public Restaurant Restaurant { get; }

        public SelectRestaurantCmd(Restaurant restaurant)
        {
            Restaurant = restaurant;
        }

        public void CheckIfValid()
        {
            if (Restaurant == null)
            {
                throw new Exception("The restaurant does not exist");
            }
        }
    }
}