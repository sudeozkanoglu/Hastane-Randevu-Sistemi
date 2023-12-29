using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using webProjeOdev.Data;
using webProjeOdev.Models;

namespace webProjeOdev.Controllers
{
    [Authorize]
    public class AnaBilimDaliController : Controller
    {
        private HastaneRandevuContext s = new HastaneRandevuContext();

        public IActionResult Index()
        {
            var a = s.AnaBilimDallari.ToList();
            return View(a);
        }

        public IActionResult AnaBilimDaliEkle()
        {
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
                return RedirectToAction("Index");
            }
            TempData["msj"] = "Ekleme Başarısız";
            return View(a);
        }

        public IActionResult AnaBilimDaliDuzenle(int? id)
        {
            if (id is null)
            {
                TempData["Hata"] = "Lütfen Boş Geçmeyin";
                return View("Hata");
            }
            var a = s.AnaBilimDallari.FirstOrDefault(x => x.anaBilimDaliId == id);
            if (a == null)
            {
                TempData["Hata"] = "Lütfen Geçerli Bir Ana Bilim Dalı Girin ";
                return View("Hata");

            }
            return View(a);
        }

        [HttpPost]
        public IActionResult AnaBilimDaliDuzenle(int? id, AnaBilimDali a)
        {
            if(id != a.anaBilimDaliId )
            {
                TempData["Hata"] = "Hatalı";
                return View("Hata");
            }
            ModelState.Remove(nameof(a.Hastaneler));
            ModelState.Remove(nameof(a.Klinikler));
            ModelState.Remove(nameof(a.Doktorlar));
            ModelState.Remove(nameof(a.Randevular));
            if (ModelState.IsValid)
            {
                s.AnaBilimDallari.Update(a);
                s.SaveChanges();
                return RedirectToAction("Index");
            }
            TempData["Hata"] = "Hatalı";
            return View("Hata");
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
            return RedirectToAction("Index");
        }
    }
}
