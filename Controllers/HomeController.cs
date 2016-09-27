using Microsoft.AspNetCore.Mvc;
using OdeToFood.Models;
using OdeToFood.Services;

namespace OdeToFood.Controllers
{
    public class HomeController : Controller
    {
        private IRestaurantData _restaurantData;

        public HomeController(IRestaurantData restaurantData)
        {
            _restaurantData = restaurantData;
        }

        // public ObjectResult Index()
        public ViewResult Index()
        {
            //var model = new Restaurant() { Id = 1, Name = "Sabatino's" };
            var model = _restaurantData.GetAll();

            // return Content("Hello, from a controller!");
            // return new ObjectResult(model);
            return View("Index", model);
        }
    }
}
