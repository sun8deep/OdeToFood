using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Configuration;
using OdeToFood.Core;
using OdeToFood.Data;

namespace OdeToFood.Pages.Restaurants
{
    public class ListModel : PageModel
    {
        public IEnumerable<Restaurant> Restaurants { get; set; }
        private IRestaurantData RestaurantData { get; }

        private readonly IConfiguration _configuration;

        [BindProperty(SupportsGet =true)]
        public string SearchTerm { get; set; }

       

        public ListModel(IConfiguration configuration, IRestaurantData restaurantData)
        {
            _configuration = configuration;
            RestaurantData = restaurantData;
        }
        public void OnGet()
        {
            Restaurants = RestaurantData.GetRestaurantsByName(SearchTerm);
        }
    }
}