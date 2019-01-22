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

        /// <summary>
        /// Out of the restaurants find me the first restaurant where given a restaurant r, the id property matches this incoming id parameter.
        /// The first restaurant it enconters where this lambda expression returns true it will return that object, that restaurant, If this expression never returns true,
        /// this operator will return a default value for this type restaurant, since restaurant is reference type it will return null if id cannot be located.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Restaurant Get(int id)
        {
            return _restaurants.FirstOrDefault(r => r.ID == id);
        }

        public Restaurant Add(Restaurant restaurant)
        {
            restaurant.ID = _restaurants.Max(r => r.ID) + 1;
            _restaurants.Add(restaurant);
            return restaurant;
        }

        List<Restaurant> _restaurants;
    }
}
