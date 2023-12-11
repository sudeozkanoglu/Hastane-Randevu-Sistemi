using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using webProjeOdev.Data;
using webProjeOdev.Models;

namespace webProjeOdev.Controllers
{
    public class HastaneAnaBilimController : Controller
    {
        private HastaneRandevuContext w = new HastaneRandevuContext();

        public IActionResult Index()
        {
            return View();
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
    }
}
