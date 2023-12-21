using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
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
        public IActionResult HastaneSil(int? id)//Hastaneyi sildigimde icinde hastaneyle ilgili bilgi olanlarin hepsini silebiliriz aslinda
        {
            if (id == null)
            {
                TempData["hata"] = " Lütfen bos gecmeyiniz";
                return View("HastaneHata");
            }
            var r = g.Hastaneler.Include(x => x.Randevular)
                .FirstOrDefault(x => x.hastaneId == id);//O hastanede var olan randevulari listeler
            if (r == null)
            {
                TempData["hata"] = " Hastaneye ait kayit bulunamadi";
                return View("HastaneHata");
            }
            if (r.Randevular.Count() > 0)
            {
                TempData["hata"] = " Hastaneye ait randevular var once randevulari iptal et";
                return View("HastaneHata");
            }
            var d = g.Hastaneler.Include(x => x.Doktorlar)
              .FirstOrDefault(x => x.hastaneId == id);//O hastanede var olan randevulari listeler
            if (d == null)
            {
                TempData["hata"] = " Hastaneye ait kayit bulunamadi";
                return View("HastaneHata");
            }
            if (d.Doktorlar.Count() > 0)
            {
                TempData["hata"] = "Hastaneye kayitli doktorlar var önce doktorlari sil";
                return View("HastaneHata");
            }
            g.Hastaneler.Remove(d);
            g.SaveChanges();
            TempData["hata"] = " Doktor silindi";
            return RedirectToAction("DoktorListele");
        }
        public IActionResult HastaneHata()
        {
            var y = g.Hastaneler.ToList();
            return View(y);
        }
    }
}
