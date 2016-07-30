using Microsoft.AspNetCore.Mvc;

namespace GymWebsite.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return Content("Welcome");
        }
    }
}