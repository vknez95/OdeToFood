using Microsoft.AspNetCore.Mvc;

namespace OdeToFood.Controllers
{
    // [Route("about")]
    // [Route("[controller]/[action]")]
    // [Route("company/[controller]/[action]")]
    public class AboutController
    {
        // [Route("")]
        public string Phone()
        {
            return "+1-555-555-5555";
        }

        // [Route("country")]
        // [Route("[action]")]
        public string Country()
        {
            return "USA";
        }
    }
}
