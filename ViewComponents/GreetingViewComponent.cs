using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using OdeToFood.Services;

namespace OdeToFood.ViewComponents
{
    public class GreetingViewComponent : ViewComponent
    {
        private IGreeter _greeter;

        public GreetingViewComponent(IGreeter greeter)
        {
            _greeter = greeter;
        }

        // Both Invoke and InvokeAsync work
        // public IViewComponentResult Invoke()
        // {
        //     var model = _greeter.GetGreeting();
        //     return View("Default", model);
        // }

        public Task<IViewComponentResult> InvokeAsync()
        {
            var model = _greeter.GetGreeting();
            return Task.FromResult<IViewComponentResult>(View("Default", model));
        }
    }
}