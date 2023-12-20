using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using webProjeOdev.Data;
using webProjeOdev.Models;

namespace webProjeOdev.Controllers
{
    [Authorize]
    public class KlinikController : Controller
    {
        private HastaneRandevuContext g = new HastaneRandevuContext();
        public IActionResult Index()
        {
            var k = g.Klinikler.Include(x => x.AnaBilimDali).ToList();
            return View(k);
        }

        public IActionResult KlinikEkle()
        {
            ViewBag.AnaBilimDaliList = new SelectList(g.AnaBilimDallari.ToList(), "anaBilimDaliId", "anaBilimDaliAdi");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult KlinikEkle(Klinik k)
        {
            ModelState.Remove(nameof(k.Poliklinikler));
            ModelState.Remove(nameof(k.Doktorlar));
            ModelState.Remove(nameof(k.Randevular));
            ModelState.Remove(nameof(k.AnaBilimDali));
            ModelState.Remove(nameof(k.HastaneKlinikler));
            ModelState.Remove(nameof(k.Hastaneler));
            if (ModelState.IsValid)
            {
                g.Klinikler.Add(k);
                g.SaveChanges();
                TempData["msj"] = k.klinikAdi + "Klinik Eklendi";
                return RedirectToAction("Index");
            }
            ViewBag.AnaBilimDaliList = new SelectList(g.AnaBilimDallari.ToList(), "anaBilimDaliId", "anaBilimDaliAdi");
            TempData["msj"] = "Ekleme Başarısız";
            return View(k);
        }


        public IActionResult KlinikDuzenle(int? id)
        {
            if (id is null)
            {
                TempData["hata"] = "Lütfen boş geçmeyiniz";
                return View("Hata");
            }
            var k = g.Klinikler.FirstOrDefault(x => x.klinikId == id);
            if (k == null)
            {
                TempData["hata"] = "Lütfen geçerli bir yazar giriniz ";
                return View("Hata");

            }
            ViewBag.AnaBilimDaliList = new SelectList(g.AnaBilimDallari.ToList(), "anaBilimDaliId", "anaBilimDaliAdi");
            return View(k);
        }

        [HttpPost]
        public IActionResult KlinikDuzenle(int? id, Klinik k)
        {
            if (id != k.klinikId)
            {
                TempData["Hata"] = "Hatalı";
                return View("Hata");
            }
            ModelState.Remove(nameof(k.Poliklinikler));
            ModelState.Remove(nameof(k.Doktorlar));
            ModelState.Remove(nameof(k.Randevular));
            ModelState.Remove(nameof(k.AnaBilimDali));
            ModelState.Remove(nameof(k.HastaneKlinikler));
            ModelState.Remove(nameof(k.Hastaneler));
            if (ModelState.IsValid)
            {
                g.Klinikler.Update(k);
                g.SaveChanges();
                return RedirectToAction("Index");
            }
            TempData["Hata"] = "Hatalı";
            return View("Hata");
        }
    }
}
