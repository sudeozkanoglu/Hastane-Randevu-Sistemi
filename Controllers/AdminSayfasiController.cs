using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace webProjeOdev8.Controllers
{
    public class AdminSayfasiController : Controller
    {
        [Authorize]
        public IActionResult Index()
        {
            return View();
        }
    }
}
