using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using WebProjeOdev8.Data;
using webProjeOdev8.Models;
using Microsoft.EntityFrameworkCore;

namespace webProjeOdev8.Controllers
{
    public class HastaneKlinikController : Controller
    {

        private HastaneRandevuContext hc = new HastaneRandevuContext();
        public IActionResult Sil(int? id1, int? id2)
        {
           
            var hastaneKlinik = hc.HastaneKlinikler
                       .SingleOrDefault(x => x.Hastane.hastaneId == id1 && x.Klinik.klinikId == id2);

            if (hastaneKlinik == null)
            {
                TempData["hata"] = "Belirtilen öğe bulunamadı";
                return View("Hata");
            }

            hc.HastaneKlinikler.Remove(hastaneKlinik);
            hc.SaveChanges();

            return RedirectToAction("Listele");
        }
        public IActionResult Listele()
        {
            var y = hc.HastaneKlinikler.Include(hab => hab.Hastane).Include(hab => hab.Klinik).ToList();
            return View(y);
        }
        public IActionResult Hata()
        {
            return View();
        }

        public IActionResult HastaneKlinikEkle()
        {
            var y1 = from klinik in hc.Klinikler
                     join anaBilim in hc.HastanedekiAnaBilimler on klinik.anaBilimDaliId equals anaBilim.anaBilimDaliId
                     where klinik.anaBilimDaliId == anaBilim.anaBilimDaliId
                     select klinik;
            ViewBag.HastaneList = new SelectList(hc.Hastaneler.ToList(), "hastaneId", "hastaneAdi");
            ViewBag.KlinikList = new SelectList(y1.ToList(), "klinikId", "klinikAdi");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult HastaneKlinikEkle(HastaneKlinik hk)
        {
            ModelState.Remove(nameof(hk.Hastane));
            ModelState.Remove(nameof(hk.Klinik));
            if (ModelState.IsValid)
            {
                hc.HastaneKlinikler.Add(hk);
                hc.SaveChanges();
                TempData["msj"] = "Ekleme Başarılı";
                return RedirectToAction("Listele");
            }
            TempData["msj"] = "Ekleme Başarısız";
            return View(hk);

        }
    }
}
