using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace webProjeOdev.Controllers
{
   
    public class AdminSayfasiController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
