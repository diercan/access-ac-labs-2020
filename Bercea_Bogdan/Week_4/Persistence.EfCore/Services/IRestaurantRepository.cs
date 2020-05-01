using System;
using System.Collections.Generic;
using System.Text;

namespace Persistence.EfCore.Services
{
    public interface IRestaurantRepository
    {
        IEnumerable<Restaurant> GetRestaurants();
        Restaurant GetRestaurant(Guid restaurantId);
        void AddRestaurant(Restaurant restauran);
        void DeleteRestaurant(Restaurant restaurant);
        void UpdateRestaurant(Restaurant restaurant);

        bool Save();
    }
}
