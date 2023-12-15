using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace webProjeOdev2.Controllers
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
