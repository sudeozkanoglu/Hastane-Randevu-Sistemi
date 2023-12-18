using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using webProjeOdev8.Models;
using WebProjeOdev8.Data;

namespace webProjeOdev8.Controllers
{
    public class HastaneController : Controller
    {
        private HastaneRandevuContext g = new HastaneRandevuContext();

        public IActionResult HastaneEkle()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult HastaneEkle(Hastane h)
        {

            ModelState.Remove(nameof(h.Klinikler));
            ModelState.Remove(nameof(h.Doktorlar));
            ModelState.Remove(nameof(h.Randevular));
            ModelState.Remove(nameof(h.HastaneHastalar));
            ModelState.Remove(nameof(h.Hastalar));
            ModelState.Remove(nameof(h.HastaneAnaBilimler));
            ModelState.Remove(nameof(h.AnaBilimDallari));
            ModelState.Remove(nameof(h.HastaneKlinikler));
            ModelState.Remove(nameof(h.HastanePoliklinikler));
            ModelState.Remove(nameof(h.Poliklinikler));
            if (ModelState.IsValid)
            {
                g.Hastaneler.Add(h);
                g.SaveChanges();
                TempData["msj"] = h.hastaneAdi + "Hastane Eklendi";
                return RedirectToAction("Index");
            }
            TempData["msj"] = "Ekleme Başarısız";
            return View(h);
        }
        public IActionResult Index()
        {
            var y = g.Hastaneler.ToList();
            return View(y);
        }
    }
}
