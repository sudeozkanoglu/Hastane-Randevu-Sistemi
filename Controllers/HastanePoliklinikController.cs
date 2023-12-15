using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using WebProjeOdev2.Data;
using webProjeOdev2.Models;

namespace webProjeOdev2.Controllers
{
    public class HastanePoliklinikController : Controller
    {
        private HastaneRandevuContext hp = new HastaneRandevuContext();

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult HastanePoliklinikEkle()
        {
            var x = from poliklinik in hp.Poliklinikler
                    join klinik in hp.HastaneKlinikler on poliklinik.klinikId equals klinik.klinikId
                    where poliklinik.klinikId == klinik.klinikId
                    select poliklinik;

            ViewBag.HastaneList = new SelectList(hp.Hastaneler.ToList(), "hastaneId", "hastaneAdi");
            ViewBag.PoliklinikList = new SelectList(x.ToList(), "poliklinikId", "poliklinikAdi");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult HastanePoliklinikEkle(HastanePoliklinik ph)
        {
            ModelState.Remove(nameof(ph.Hastane));
            ModelState.Remove(nameof(ph.Poliklinik));
            if (ModelState.IsValid)
            {
                hp.HastanePoliklinikler.Add(ph);
                hp.SaveChanges();
                TempData["msj"] = "Başarılı";
                return RedirectToAction("Index");
            }
            TempData["msj"] = "Başarısız";
            return View(ph);
        }
    }
}
