using Microsoft.AspNetCore.Mvc;
using WebProjeOdev8.Data;
using webProjeOdev8.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace webProjeOdev8.Controllers
{
    public class AnaBilimDaliController : Controller
    {
        private HastaneRandevuContext s = new HastaneRandevuContext();

        public IActionResult Listele()
        {
            var y = s.AnaBilimDallari.ToList();
            return View(y);
        }
        public IActionResult Sil(int? id)
        {
            var h = s.AnaBilimDallari.Include(x => x.Hastaneler).FirstOrDefault(x => x.anaBilimDaliId == id);

            if (h.Hastaneler.Count() > 0)
            {
                TempData["hata"] = " Hastanelerde Anabilim mevcut. Anabilimi silmek istiyorsaniz önce hastaneleri silmelisiniz";
                return View("Hata");
            }
            var d = s.AnaBilimDallari.Include(x => x.Doktorlar).FirstOrDefault(x => x.anaBilimDaliId == id);
           
            if (d.Doktorlar.Count() > 0)
            {
                TempData["hata"] = " O Anabilimde calisan doktorlar var. Anabilimi silmek istiyorsaniz önce doktoru silin";
                return View("Hata");
            }
            var k = s.AnaBilimDallari.Include(x => x.Klinikler).FirstOrDefault(x => x.anaBilimDaliId == id);

            if (k.Klinikler.Count() > 0)
            {
                TempData["hata"] = " O Anabilime ait klinikler var. Anabilimi silmek istiyorsaniz önce klinikleri silin";
                return View("Hata");
            }
            var r = s.AnaBilimDallari.Include(x => x.Randevular).FirstOrDefault(x => x.anaBilimDaliId == id);

            if (r.Randevular.Count() > 0)
            {
                TempData["hata"] = "O anabilime ait randevular var. Anabilimi silmek istiyorsaniz önce randevulari iptal edin";
                return View("Hata");
            }
            s.AnaBilimDallari.Remove(r);
            s.SaveChanges();
            TempData["hata"] = " Doktor silindi";
            return RedirectToAction("Listele");
        }
        public IActionResult Hata()
        {
            return View();
        }
        public IActionResult AnaBilimDaliEkle()
        {
            ViewBag.HastaneList = new SelectList(s.Hastaneler.ToList(), "hastaneId", "hastaneAdi");

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult AnaBilimDaliEkle(AnaBilimDali a)
        {
            ModelState.Remove(nameof(a.Hastaneler));
            ModelState.Remove(nameof(a.Klinikler));
            ModelState.Remove(nameof(a.Doktorlar));
            ModelState.Remove(nameof(a.Randevular));
            if (ModelState.IsValid)
            {
                s.AnaBilimDallari.Add(a);
                s.SaveChanges();
                TempData["msj"] = a.anaBilimDaliAdi + "Ana Bilim Dalı Eklendi";
                return RedirectToAction("Listele");
            }
            TempData["msj"] = "Ekleme Başarısız";
            return View(a);
        }
    }
}

