using OdeToFood.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OdeToFood.Data
{
    public class InMemoryRestaurantData : IRestaurantData
    {
        #region Fields && Properties

        private IList<Restaurant> restaurants;

        #endregion

        #region Constructor

        public InMemoryRestaurantData()
        {
            restaurants = new List<Restaurant>()
            { new Restaurant() { Id = 1, Cuisine = CuisineType.Indian, Name = "Scott's Pizza", Location = "Maryland" } ,
                new Restaurant() { Id = 2, Cuisine = CuisineType.Italian, Name = "Burger", Location = "Toronto" },
                new Restaurant() { Id = 3, Cuisine = CuisineType.Meican, Name = "Biryani", Location = "Gachibowli" }};
        }

        #endregion

        #region Methods

        public IEnumerable<Restaurant> GetRestaurantsByName(string searchTerm)
        {
            return from restaurant in restaurants
                   where string.IsNullOrWhiteSpace(searchTerm) || restaurant.Name.StartsWith(searchTerm)
                   orderby restaurant.Name
                   select restaurant;
        }

        public Restaurant GetById(int restaurantId)
        {
            return restaurants.SingleOrDefault(x => x.Id == restaurantId);
        }

        public void Add(Restaurant newRestaurant)
        {
            newRestaurant.Id = restaurants.Max(x => x.Id) + 1;
            restaurants.Add(newRestaurant);
        }

        public Restaurant Update(Restaurant updatedRestaurant)
        {
            var restaurant = restaurants.SingleOrDefault(x => x.Id == updatedRestaurant.Id);
            if(restaurant != null)
            {
                restaurant.Name = updatedRestaurant.Name;
                restaurant.Location = updatedRestaurant.Location;
                restaurant.Cuisine = updatedRestaurant.Cuisine;
            }

            return restaurant;
        }

        public int Commit()
        {
            return 0;
        }

        #endregion
    }
}
