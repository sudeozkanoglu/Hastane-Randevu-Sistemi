using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace webProjeOdev8.Controllers
{
    [Authorize(Roles = "user")]
    public class UserSayfasiController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
