using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using webProjeOdev.Data;
using webProjeOdev.Models;

namespace webProjeOdev.Controllers
{
    [Authorize]
    public class PoliklinikController : Controller
    {
        private HastaneRandevuContext q = new HastaneRandevuContext();
        public IActionResult Index()
        {
            var p = q.Poliklinikler.Include(x => x.Klinik).Include(y => y.Doktor).ToList();
            return View(p);
        }

        public IActionResult Success()
        {
            return View();
        }
        private List<SelectListItem> GetDoktor(int klinikId)
        {
            List<SelectListItem> lstDoktorlar = q.Doktorlar
                .Where(c => c.klinikId == klinikId)
                .OrderBy(n => n.doktorId)
                .Select(n =>
                new SelectListItem
                {
                    Value = n.doktorId.ToString(),
                    Text = n.doktorAdi.ToString() + " " + n.doktorSoyadi.ToString()
                }).ToList();
            var defItem = new SelectListItem()
            {
                Value = "",
                Text = "--Select doktor--"
            };
            lstDoktorlar.Insert(0, defItem);
            return lstDoktorlar;
        }
        public JsonResult GetDoktorByKlinik(int klinikId)
        {
            List<SelectListItem> doktorlar = GetDoktor(klinikId);
            return Json(doktorlar);
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
                return RedirectToAction("Index");
            }
            ViewBag.KlinikList = new SelectList(q.Klinikler.ToList(), "klinikId", "klinikAdi");
            TempData["msj"] = "Ekleme Başarısız";
            return View(l);
        }

        public IActionResult PoliklinikDuzenle(int? id)
        {
            if (id is null)
            {
                TempData["hata"] = "Lütfen boş geçmeyiniz";
                return View("Hata");
            }
            var k = q.Poliklinikler.FirstOrDefault(x => x.poliklinikId == id);
            if (k == null)
            {
                TempData["hata"] = "Lütfen geçerli bir yazar giriniz ";
                return View("Hata");

            }
            ViewBag.KlinikList = new SelectList(q.Klinikler.ToList(), "klinikId", "klinikAdi");
            return View(k);
        }

        [HttpPost]
        public IActionResult PoliklinikDuzenle(int? id, Poliklinik r)
        {
            if (id != r.poliklinikId)
            {
                TempData["Hata"] = "Hatalı";
                return View("Hata");
            }
            ModelState.Remove(nameof(r.Klinik));
            ModelState.Remove(nameof(r.Randevular));
            ModelState.Remove(nameof(r.HastanePoliklinikler));
            ModelState.Remove(nameof(r.Hastaneler));
            ModelState.Remove(nameof(r.Doktor));
            if (ModelState.IsValid)
            {
                q.Poliklinikler.Update(r);
                q.SaveChanges();
                return RedirectToAction("Index");
            }
            TempData["Hata"] = "Hatalı";
            return View("Hata");
        }
    }
}
