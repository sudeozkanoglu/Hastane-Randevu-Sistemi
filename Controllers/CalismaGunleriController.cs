using Microsoft.AspNetCore.Mvc;
using webProjeOdev8.Models;
using WebProjeOdev8.Data;

namespace webProjeOdev8.Controllers
{
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
