using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using webProjeOdev8.Models;
using WebProjeOdev8.Data;

namespace webProjeOdev8.Controllers
{
    public class HastaneAnaBilimController : Controller
    {
        private HastaneRandevuContext s = new HastaneRandevuContext();

        public IActionResult HastaneAnaBilimEkle()
        {
            ViewBag.HastaneList = new SelectList(s.Hastaneler.ToList(), "hastaneId", "hastaneAdi");
            ViewBag.AnaBilimList = new SelectList(s.AnaBilimDallari.ToList(), "anaBilimDaliId", "anaBilimDaliAdi");

            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult HastaneAnaBilimEkle(HastaneAnaBilim hab)
        {
            ModelState.Remove(nameof(hab.Hastane));
            ModelState.Remove(nameof(hab.AnaBilimDali));
            if (ModelState.IsValid)
            {
                s.HastanedekiAnaBilimler.Add(hab);
                s.SaveChanges();
                return RedirectToAction("Listele");
            }
            return View();
        }
     
        public IActionResult Sil(int? id1, int? id2)
        {
            if (id1 is null || id2 is null)
            {
                TempData["hata"] = "Lütfen silinecek alanı seçiniz";
                return View("Hata");
            }

            var hastaneAnaBilim = s.HastanedekiAnaBilimler
                       .FirstOrDefault(x => x.Hastane.hastaneId == id1 && x.AnaBilimDali.anaBilimDaliId == id2);

            if (hastaneAnaBilim == null)
            {
                TempData["hata"] = "Belirtilen öğe bulunamadı";
                return View("Hata");
            }

            s.HastanedekiAnaBilimler.Remove(hastaneAnaBilim);
            s.SaveChanges();

            return RedirectToAction("Listele");
        }
        public IActionResult Listele()
        {
            var y = s.HastanedekiAnaBilimler.Include(hab=>hab.Hastane).Include(hab=>hab.AnaBilimDali).ToList();
            return View(y);
        }
        public IActionResult Hata()
        {
            return View();
        }
    }
}
