using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace webProjeSon.Controllers
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
