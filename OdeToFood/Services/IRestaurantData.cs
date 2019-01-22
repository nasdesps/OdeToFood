using OdeToFood.Models;
using System.Collections.Generic;

namespace OdeToFood.Services
{
    public interface IRestaurantData
    {
        // for list of restaurant
        IEnumerable<Restaurant> GetAll();

        //for single restaurant
        Restaurant Get(int id);
        Restaurant Add(Restaurant restaurant);
    }
}
