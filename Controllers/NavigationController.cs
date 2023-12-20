using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace webProjeOdev.Controllers
{
    [Authorize]
    public class NavigationController : Controller
    {
        public IActionResult HastaneNavigation()
        {
            return View();
        }

        public IActionResult AnaBilimNavigation()
        {
            return View();
        }

        public IActionResult KlinikNavigation()
        {
            return View();
        }

        public IActionResult PoliklinikNavigation()
        {
            return View();
        }

        public IActionResult DoktorNavigation()
        {
            return View();
        }

        public IActionResult HastaNavigation()
        {
            return View();
        }
    }
}
