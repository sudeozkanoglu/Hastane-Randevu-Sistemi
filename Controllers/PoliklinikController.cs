using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using webProjeOdev.Data;
using webProjeOdev.Models;

namespace webProjeOdev.Controllers
{
    public class PoliklinikController : Controller
    {
        private HastaneRandevuContext q = new HastaneRandevuContext();
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Success()
        {
            return View();
        }

        public IActionResult PoliklinikEkle()
        {
            ViewBag.KlinikList = new SelectList(q.Klinikler.ToList(), "klinikId", "klinikAdi");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult PoliklinikEkle(Poliklinik l)
        {
            ModelState.Remove(nameof(l.Klinik));
            ModelState.Remove(nameof(l.Randevular));
            ModelState.Remove(nameof(l.HastanePoliklinikler));
            ModelState.Remove(nameof(l.Hastaneler));
            ModelState.Remove(nameof(l.Doktor));

            if (ModelState.IsValid)
            {
                q.Poliklinikler.Add(l);
                q.SaveChanges();
                TempData["msj"] = l.poliklinikAdi + "Klinik Eklendi";
                return RedirectToAction("Success");
            }
            ViewBag.KlinikList = new SelectList(q.Klinikler.ToList(), "klinikId", "klinikAdi");
            TempData["msj"] = "Ekleme Başarısız";
            return View(l);
        }
    }
}
