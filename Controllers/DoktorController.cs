using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
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

            return View(d);
        }
        public IActionResult DoktorListele()
        {
            var y = a.Doktorlar.ToList();
            return View(y);
        }

    }
}
