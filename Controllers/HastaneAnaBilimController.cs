using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.SignalR;
using Microsoft.EntityFrameworkCore;
using webProjeOdev.Data;
using webProjeOdev.Models;

namespace webProjeOdev.Controllers
{
    [Authorize]
    public class HastaneAnaBilimController : Controller
    {
        private HastaneRandevuContext w = new HastaneRandevuContext();

        public IActionResult Index()
        {
            var ha = w.HastaneAnaBilimler.Include(x => x.Hastane).Include(y => y.AnaBilimDali).ToList();
            return View(ha);
        }

        public IActionResult HastaneAnaBilimEkle()
        {
            ViewBag.AnaBilimDaliList = new SelectList(w.AnaBilimDallari.ToList(), "anaBilimDaliId", "anaBilimDaliAdi");
            ViewBag.HastaneList = new SelectList(w.Hastaneler.ToList(), "hastaneId", "hastaneAdi");
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
                w.HastaneAnaBilimler.Add(hab);
                w.SaveChanges();
                TempData["msj"] = "Ekleme Başarılı";
                return RedirectToAction("Index");
            }
            ViewBag.AnaBilimDaliList = new SelectList(w.AnaBilimDallari.ToList(), "anaBilimDaliId", "anaBilimDaliAdi");
            ViewBag.HastaneList = new SelectList(w.Hastaneler.ToList(), "hastaneId", "hastaneAdi");
            TempData["msj"] = "Ekleme Başarısız";
            return View(hab);
        }

        public IActionResult Sil(int? id1, int? id2)
        {
            if (id1 is null || id2 is null)
            {
                TempData["hata"] = "Lütfen silinecek alanı seçiniz";
                return View("Hata");
            }

            var hastaneAnaBilim = w.HastaneAnaBilimler
                       .FirstOrDefault(x => x.Hastane.hastaneId == id1 && x.AnaBilimDali.anaBilimDaliId == id2);

            if (hastaneAnaBilim == null)
            {
                TempData["hata"] = "Belirtilen öğe bulunamadı";
                return View("Hata");
            }

            w.HastaneAnaBilimler.Remove(hastaneAnaBilim);
            w.SaveChanges();

            return RedirectToAction("Index");
        }
    }
}
