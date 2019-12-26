using OdeToFood.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OdeToFood.Data
{
    public interface IRestaurantData
    {
        IEnumerable<Restaurant> GetRestaurantsByName(string searchTerm);
    }

    public class InMemoryRestaurantData : IRestaurantData
    {
        private IList<Restaurant> restaurants;

        public InMemoryRestaurantData()
        {
            restaurants = new List<Restaurant>()
            { new Restaurant() { Id = 1, Cuisine = CuisineType.Indian, Name = "Scott's Pizza", Location = "Maryland" } ,
                new Restaurant() { Id = 1, Cuisine = CuisineType.Italian, Name = "Burger", Location = "Toronto" },
                new Restaurant() { Id = 1, Cuisine = CuisineType.Meican, Name = "Biryani", Location = "Gachibowli" }};
        }
        public IEnumerable<Restaurant> GetRestaurantsByName(string searchTerm)
        {
            return from restaurant in restaurants
                   where string.IsNullOrWhiteSpace(searchTerm) || restaurant.Name.StartsWith(searchTerm)
                   orderby restaurant.Name
                   select restaurant;
        }
    }
}
