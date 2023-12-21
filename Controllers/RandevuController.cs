using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using webProjeOdev8.Models;
using WebProjeOdev8.Data;

namespace webProjeOdev8.Controllers
{
    public class RandevuController : Controller
    {
        private HastaneRandevuContext a = new HastaneRandevuContext();

        public IActionResult Hata()
        {
            return View();
        }
        public IActionResult Listele()
        {
            var y = a.Randevular.ToList();
            return View(y);
        }
        private List<SelectListItem> GetDoktor(int hastaneId, int klinikId)
        {
            List<SelectListItem> lstDoktorlar = a.Doktorlar
                .Where(c => c.hastaneId == hastaneId)
                .Where(c=>c.klinikId==klinikId)
                .OrderBy(n => n.doktorAdi)
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
        public JsonResult GetDoktorByHastaneAndKlinik(int hastaneId,int klinikId)
        {
            List<SelectListItem> doktorlar = GetDoktor(hastaneId,klinikId);
            return Json(doktorlar);
        }
        private List<SelectListItem> GetPoliklinik(int doktorId)
        {
            List<SelectListItem> lstPoliklinikler = a.Poliklinikler
                .Where(c => c.doktorId == doktorId)
                .OrderBy(n => n.poliklinikId)
                .Select(n =>
                new SelectListItem
                {
                    Value = n.poliklinikId.ToString(),
                    Text = n.poliklinikAdi.ToString()
                }).ToList();
            var defItem = new SelectListItem()
            {
                Value = "",
                Text = "--Select poliklinik--"
            };
            lstPoliklinikler.Insert(0, defItem);
            return lstPoliklinikler;
        }
        public JsonResult GetPoliklinikByDoktor(int doktorId)
        {
            List<SelectListItem> poliklinikler = GetPoliklinik(doktorId);
            return Json(poliklinikler);
        }
        public IActionResult RandevuEkle()
        {
            ViewBag.HastaneList = new SelectList(a.Hastaneler.ToList(), "hastaneId", "hastaneAdi");
           
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult RandevuEkle(Randevu r)
        {
            DayOfWeek haftaninGunu = r.randevuTarihi.DayOfWeek;//haftanin hangi günü oldugunu bulur


            var ran = a.Randevular.Where(a => a.randevuTarihi == r.randevuTarihi && a.randevuSaat == r.randevuSaat).ToList();
            if (ran.Count() > 0)
            {
                TempData["hata"] = "O gün ve saat dolu. Lütfen baska bir gün seciniz.";
                return RedirectToAction(nameof(Hata));
            }
            ModelState.Remove(nameof(r.Hastane));
            ModelState.Remove(nameof(r.AnaBilimDali));
            ModelState.Remove(nameof(r.Klinik));
            ModelState.Remove(nameof(r.Poliklinik));
            ModelState.Remove(nameof(r.Doktor));
            ModelState.Remove(nameof(r.Hasta));

            if (ModelState.IsValid)
            {
                a.Randevular.Add(r);
                a.SaveChanges();
                return RedirectToAction("Listele");
            }

            return View(r);
        }
    }
}
