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

        public IActionResult HastaneAnaBilimDuzenle(int? id , int? id2)
        {
            if (id is null || id2 is null)
            {
                TempData["hata"] = "Lütfen boş geçmeyiniz";
                return View("Hata");
            }
            var k = w.HastaneAnaBilimler.FirstOrDefault(x => x.hastaneId == id && x.anaBilimDaliId == id2);
            if (k == null)
            {
                TempData["hata"] = "Lütfen geçerli bir yazar giriniz ";
                return View("Hata");

            }
            ViewBag.AnaBilimDaliList = new SelectList(w.AnaBilimDallari.ToList(), "anaBilimDaliId", "anaBilimDaliAdi");
            ViewBag.HastaneList = new SelectList(w.Hastaneler.ToList(), "hastaneId", "hastaneAdi");
            return View(k);
        }

        [HttpPost]
        public IActionResult HastaneAnaBilimDuzenle(int? id, int? id2 , HastaneAnaBilim ah)
        {
            if (id != ah.hastaneId || id2 != ah.anaBilimDaliId)
            {
                TempData["Hata"] = "Hatalı";
                return View("Hata");
            }
            ModelState.Remove(nameof(ah.Hastane));
            ModelState.Remove(nameof(ah.AnaBilimDali));
            if (ModelState.IsValid)
            {
                w.HastaneAnaBilimler.Update(ah);
                w.SaveChanges();
                return RedirectToAction("Index");
            }
            TempData["Hata"] = "Hatalı";
            return View("Hata");
        }
    }
}
