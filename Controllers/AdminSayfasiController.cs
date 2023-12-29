using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Mvc;
using webProjeSon.Services;

namespace webProjeOdev.Controllers
{
    [Authorize]
    public class AdminSayfasiController : Controller
    {
        private readonly LanguageService _localizer;

        public IActionResult Index()
        { 
            return View();
        }
    }
}
