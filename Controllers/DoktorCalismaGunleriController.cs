using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.SignalR;
using Microsoft.EntityFrameworkCore;
using webProjeOdev8.Models;
using WebProjeOdev8.Data;

namespace webProjeOdev8.Controllers
{
    public class DoktorCalismaGunleriController : Controller
    {
        private HastaneRandevuContext s = new HastaneRandevuContext();

        public IActionResult Listele()
        {
            var d = s.DoktorCalismaGunler.Include(a => a.Doktor).Include(a => a.CalismaGunleri).ToList();
            return View(d);
        }
        private List<SelectListItem> GetDoktor()
        {
            List<SelectListItem> lstDoktorlar = s.Doktorlar
                .OrderBy(n => n.doktorId)
                .Select(n =>
                new SelectListItem
                {
                    Value = n.doktorId.ToString(),
                    Text = n.doktorAdi.ToString() + " " + n.doktorSoyadi.ToString()
                }).ToList();
          
            return lstDoktorlar;
        }
        private List<SelectListItem> GetGunler()
        {
            List<SelectListItem> lstGunler = s.CalismaGunleri
                .OrderBy(n => n.calismaGunleriId)
                .Select(n =>
                new SelectListItem
                {
                    Value = n.calismaGunleriId.ToString(),
                    Text = n.calismaGunleri.ToString() + " " + n.baslamaSaati.ToString() + "-" + n.bitisSaati.ToString()
                }).ToList();

            return lstGunler;
        }
        public IActionResult DoktorCalismaGunuEkle()
        {
            ViewBag.DoktorList = GetDoktor();
            ViewBag.CalismaGunleriList = GetGunler();
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult DoktorCalismaGunuEkle(DoktorCalismaGunleri dcg)
        {
            ModelState.Remove(nameof(dcg.Doktor));
            ModelState.Remove(nameof(dcg.CalismaGunleri));
            if (ModelState.IsValid)
            {
                s.DoktorCalismaGunler.Add(dcg);
                s.SaveChanges();
                return View(nameof(Listele));
            }
            return View(dcg);
        }
        public IActionResult Sil(int? id1, int? id2)
        {
            if (id1 is null || id2 is null)
            {
                TempData["hata"] = "Lütfen silinecek alanı seçiniz";
                return View("Hata");
            }
            var doktorCalGun = s.DoktorCalismaGunler
                       .FirstOrDefault(x => x.Doktor.doktorId == id1 && x.CalismaGunleri.calismaGunleriId == id2);

            if (doktorCalGun == null)
            {
                TempData["hata"] = "Belirtilen öğe bulunamadı";
                return View("Hata");
            }

            s.DoktorCalismaGunler.Remove(doktorCalGun);
            s.SaveChanges();

            return RedirectToAction("Listele");
        }
    }
}
