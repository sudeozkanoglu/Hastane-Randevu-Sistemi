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
                TempData["hata"] = "Lütfen boş geçmeyiniz";
                return View("Hata");
            }
            var a = s.AnaBilimDallari.FirstOrDefault(x => x.anaBilimDaliId == id);
            if (a == null)
            {
                TempData["hata"] = "Lütfen geçerli bir yazar giriniz ";
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
    }
}
