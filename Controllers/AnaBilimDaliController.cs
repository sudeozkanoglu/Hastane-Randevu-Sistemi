using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using webProjeOdev.Data;
using webProjeOdev.Models;

namespace webProjeOdev.Controllers
{
    public class AnaBilimDaliController : Controller
    {
        private HastaneRandevuContext s = new HastaneRandevuContext();

        public IActionResult Index()
        {
            var y = s.AnaBilimDallari.ToList();
            var y1 = from AnaBilimDali in s.AnaBilimDallari
                     select AnaBilimDali;
            return View(y);
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
    }
}
