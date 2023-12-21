using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using WebProjeOdev8.Data;
using webProjeOdev8.Models;

namespace webProjeOdev8.Controllers
{
    public class KlinikController : Controller
    {
        private HastaneRandevuContext g = new HastaneRandevuContext();
        public IActionResult Index()
        {
            //var t = g.Klinikler.ToList();
            var t1 = from Klinik in g.Klinikler
                     join AnaBilimDali in g.AnaBilimDallari
                     on Klinik.anaBilimDaliId equals AnaBilimDali.anaBilimDaliId
                     select new
                     {
                         klinikAdi = Klinik.klinikAdi,
                         anaBilimDaliAdi = AnaBilimDali.anaBilimDaliAdi
                     };
            return View(t1.ToList());
        }

        public IActionResult Success()
        {
            return View();
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
            ModelState.Remove(nameof(k.HastaneKlinikler));
            ModelState.Remove(nameof(k.Hastaneler));
            ModelState.Remove(nameof(k.AnaBilimDali));

            if (ModelState.IsValid)
            {
                g.Klinikler.Add(k);
                g.SaveChanges();
                TempData["msj"] = k.klinikAdi + "Klinik Eklendi";
                return RedirectToAction("Success");
            }
            ViewBag.AnaBilimDaliList = new SelectList(g.AnaBilimDallari.ToList(), "anaBilimDaliId", "anaBilimDaliAdi");
            TempData["msj"] = "Ekleme Başarısız";
            return View(k);
        }
    }
}
