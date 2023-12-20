using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using webProjeOdev.Data;
using webProjeOdev.Models;

namespace webProjeOdev.Controllers
{
    [Authorize]
    public class CalismaGunleriController : Controller
    {
        private HastaneRandevuContext c = new HastaneRandevuContext();
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult CalismaGunleriEkle()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult CalismaGunleriEkle(CalismaGunleri cg)
        {
            if (ModelState.IsValid)
            {
                c.CalismaGunleri.Add(cg);
                c.SaveChanges();

                return View();
            }
            TempData["msj"] = "Ekleme Başarısız";
            return View(cg);

        }
    }
}
