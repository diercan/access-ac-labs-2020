using Persistence.EfCore.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Persistence.EfCore.Services
{
    public class RestaurantRepository : IRestaurantRepository
    {
        private readonly OrderAndPayContext _context;

        public RestaurantRepository(OrderAndPayContext context)
        {
            _context = context ??
                throw new ArgumentNullException(nameof(context));
        }

        public void AddRestaurant(Restaurant restauran)
        {
            if (restauran == null)
                throw new ArgumentNullException(nameof(restauran));

            _context.Restaurant.Add(restauran);
        }

        public void DeleteRestaurant(Restaurant restaurant)
        {
            if (restaurant == null)
                throw new ArgumentNullException(nameof(restaurant));

            _context.Restaurant.Remove(restaurant);
        }

        public Restaurant GetRestaurant(Guid restaurantId)
        {
            if (restaurantId == Guid.Empty)
                throw new ArgumentNullException(nameof(restaurantId));

            return _context.Restaurant.Where(rest => rest.Id == restaurantId)
                .FirstOrDefault();
        }

        public IEnumerable<Restaurant> GetRestaurants()
        {
            return _context.Restaurant.ToList();
        }

        public void UpdateRestaurant(Restaurant restaurant)
        {
            // Not Implemented
        }

        public bool Save()
        {
            return (_context.SaveChanges() >= 0);
        }
    }
}
