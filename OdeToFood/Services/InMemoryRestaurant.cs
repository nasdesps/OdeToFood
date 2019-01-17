using System.Collections.Generic;
using System.Linq;
using OdeToFood.Models;

namespace OdeToFood.Services
{
    public class InMemoryRestaurant : IRestaurantData
    {
        public InMemoryRestaurant()
        {
            _restaurants = new List<Restaurant>
            {
                new Restaurant {ID = 1, Name = "Scott's Pizza Place"},
                new Restaurant {ID = 2, Name = "Tersiguels"},
                new Restaurant {ID = 3, Name = "King's Contrivance"},
            };
        }
                
        public IEnumerable<Restaurant> GetAll()
        {
            return _restaurants.OrderBy(r => r.Name); // default is ascending order
        }

        List<Restaurant> _restaurants;
    }
}
