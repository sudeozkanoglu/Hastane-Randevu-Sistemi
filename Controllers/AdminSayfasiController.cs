using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace webProjeOdev.Controllers
{
    [Authorize]
    public class AdminSayfasiController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
