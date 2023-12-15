using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using WebProjeOdev2.Data;
using webProjeOdev2.Models;

namespace webProjeOdev2.Controllers
{
    public class HastaneKlinikController : Controller
    {
        private HastaneRandevuContext hc = new HastaneRandevuContext();
        public IActionResult Index()
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
                return RedirectToAction("Index");
            }
            TempData["msj"] = "Ekleme Başarısız";
            return View(hk);

        }
    }
}
