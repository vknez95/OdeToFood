using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OdeToFood.Entities;
using OdeToFood.Services;
using OdeToFood.ViewModels;

namespace OdeToFood.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        private IRestaurantData _restaurantData;

        public HomeController(
            IRestaurantData restaurantData,
            IGreeter greeter)
        {
            _restaurantData = restaurantData;
        }

        [HttpGet]
        [AllowAnonymous]
        public ViewResult Index()
        {
            //var model = new Restaurant() { Id = 1, Name = "Sabatino's" };
            //var model = _restaurantData.GetAll();
            var model = new HomePageViewModel();
            model.Restaurants = _restaurantData.GetAll();

            // return Content("Hello, from a controller!");
            // return new ObjectResult(model);
            return View("Index", model);
        }

        [HttpGet]
        [AllowAnonymous]
        public IActionResult Details(int id)
        {
            var model = _restaurantData.Get(id);
            if (model == null)
            {
                return RedirectToAction(nameof(Index));
            }
            return View("Details", model);
        }

        [HttpGet]
        public ViewResult Create()
        {
            return View(nameof(Create));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(RestaurantEditViewModel model)
        {
            if (ModelState.IsValid)
            {
                var restaurant = new Restaurant();
                restaurant.Name = model.Name;
                restaurant.Cuisine = model.Cuisine;

                restaurant = _restaurantData.Add(restaurant);
                _restaurantData.Commit();

                return RedirectToAction(nameof(Details), new { id = restaurant.Id });
            }
            return View(nameof(Create));
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var model = _restaurantData.Get(id);
            if (model == null)
            {
                return RedirectToAction(nameof(Index));
            }
            return View(nameof(Edit), model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, RestaurantEditViewModel model)
        {
            var restaurant = _restaurantData.Get(id);
            if (ModelState.IsValid)
            {
                restaurant.Cuisine = model.Cuisine;
                restaurant.Name = model.Name;
                _restaurantData.Commit();

                return RedirectToAction(nameof(Details), new { id = restaurant.Id });
            }
            return View(nameof(Edit), restaurant);
        }
    }
}
