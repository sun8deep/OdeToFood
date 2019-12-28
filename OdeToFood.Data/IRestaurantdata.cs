using OdeToFood.Core;
using System.Collections.Generic;

namespace OdeToFood.Data
{
    public interface IRestaurantData
    {
        IEnumerable<Restaurant> GetRestaurantsByName(string searchTerm);
        Restaurant GetById(int restaurantId);
        void Add(Restaurant newRestaurant);

        Restaurant Update(Restaurant updatedRestaurant);
        int Commit();
    }
}
