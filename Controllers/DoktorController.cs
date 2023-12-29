using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using webProjeOdev.Data;
using webProjeOdev.Models;

namespace webProjeOdev.Controllers
{
    [Authorize]
    public class DoktorController : Controller
    {
        private HastaneRandevuContext a = new HastaneRandevuContext();
        public IActionResult DoktorEkle()
        {
            ViewBag.HastaneList = new SelectList(a.Hastaneler.ToList(), "hastaneId", "hastaneAdi");

            return View();
        }

        private List<SelectListItem> GetAnaBilim(int hastaneId)
        {
            List<SelectListItem> lstAnaBilimler = a.HastaneAnaBilimler
                .Where(c => c.hastaneId == hastaneId)
                .OrderBy(n => n.AnaBilimDali.anaBilimDaliAdi)
                .Select(n =>
                new SelectListItem
                {
                    Value = n.anaBilimDaliId.ToString(),
                    Text = n.AnaBilimDali.anaBilimDaliAdi
                }).ToList();
            var defItem = new SelectListItem()
            {
                Value = "",
                Text = "--Select ana bilim--"
            };
            lstAnaBilimler.Insert(0, defItem);
            return lstAnaBilimler;
        }
        public JsonResult GetAnaBilimByHastane(int hastaneId)
        {
            List<SelectListItem> anabilimler = GetAnaBilim(hastaneId);
            return Json(anabilimler);
        }

        private List<SelectListItem> GetKlinik(int anabilimId)
        {
            List<SelectListItem> lstKlinikler = a.Klinikler
                .Where(c => c.anaBilimDaliId == anabilimId)
                .OrderBy(n => n.klinikAdi)
                .Select(n =>
                new SelectListItem
                {
                    Value = n.klinikId.ToString(),
                    Text = n.klinikAdi.ToString()
                }).ToList();
            var defItem = new SelectListItem()
            {
                Value = "",
                Text = "--Select ana bilim--"
            };
            lstKlinikler.Insert(0, defItem);
            return lstKlinikler;
        }
        public JsonResult GetKlinikByHastane(int hastaneId)
        {
            List<SelectListItem> klinikler = GetKlinik(hastaneId);
            return Json(klinikler);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult DoktorEkle(Doktor d)
        {
            ModelState.Remove(nameof(d.Poliklinik));
            ModelState.Remove(nameof(d.Randevular));
            ModelState.Remove(nameof(d.Klinik));
            ModelState.Remove(nameof(d.AnaBilimDali));
            ModelState.Remove(nameof(d.Hastane));

            if (ModelState.IsValid)
            {
                a.Doktorlar.Add(d);
                a.SaveChanges();
                return RedirectToAction("DoktorListele");
            }
            ViewBag.HastaneList = new SelectList(a.Hastaneler.ToList(), "hastaneId", "hastaneAdi");
            return View(d);
        }

        public IActionResult DoktorListele()
        {
            var y = a.Doktorlar.Include(x => x.AnaBilimDali).Include(z => z.Hastane).Include(y => y.Klinik).ToList();
            return View(y);
        }


        public IActionResult DoktorDuzenle(int? id)
        {
            if (id is null)
            {
                TempData["Hata"] = "Lütfen Boş Geçmeyin";
                return View("Hata");
            }
            var t = a.Doktorlar.FirstOrDefault(x => x.doktorId == id);
            if (t == null)
            {
                TempData["Hata"] = "Lütfen Geçerli Bir Doktor Girin ";
                return View("Hata");

            }
            ViewBag.HastaneList = new SelectList(a.Hastaneler.ToList(), "hastaneId", "hastaneAdi");
            return View(t);
        }

        [HttpPost]
        public IActionResult DoktorDuzenle(int? id , Doktor dr)
        {
            if (id != dr.doktorId)
            {
                TempData["Hata"] = "Hatalı";
                return View("Hata");
            }
            ModelState.Remove(nameof(dr.Poliklinik));
            ModelState.Remove(nameof(dr.Randevular));
            ModelState.Remove(nameof(dr.Klinik));
            ModelState.Remove(nameof(dr.AnaBilimDali));
            ModelState.Remove(nameof(dr.Hastane));
            if (ModelState.IsValid)
            {
                a.Doktorlar.Update(dr);
                a.SaveChanges();
                return RedirectToAction("DoktorListele");
            }
            ViewBag.HastaneList = new SelectList(a.Hastaneler.ToList(), "hastaneId", "hastaneAdi");
            TempData["Hata"] = "Hatalı";
            return View("Hata");
        }

        public IActionResult DoktorSil(int? id)
        {
            if (id == null)//Gereksizzzzzzzzzzzzzzzzzz
            {
                TempData["hata"] = " Lütfen bos gecmeyiniz";
                return View("DoktorHata");
            }
            var d = a.Doktorlar.Include(x => x.Randevular).FirstOrDefault(x => x.doktorId == id);//Randevusu olan doktorlari listeler
            if (d == null)//Gereksizzzzzzzzzzzzzzzzzzzzz
            {
                TempData["hata"] = " Doktora ait kayit bulunamadi";
                return View("DoktorHata");
            }
            if (d.Randevular.Count() > 0)
            {
                TempData["hata"] = " Doktora ait randevular var once randevulari iptal et";
                return View("DoktorHata");
            }
            a.Doktorlar.Remove(d);
            a.SaveChanges();
            TempData["hata"] = " Doktor silindi";
            return RedirectToAction("DoktorListele");
        }
    }
}
