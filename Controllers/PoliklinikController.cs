using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using WebProjeOdev8.Data;
using webProjeOdev8.Models;

namespace webProjeOdev8.Controllers
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
        private List<SelectListItem> GetDoktor(int klinikId)
        {
            List<SelectListItem> lstDoktorlar = q.Doktorlar
                .Where(c => c.klinikId == klinikId)
                .OrderBy(n => n.doktorId)
                .Select(n =>
                new SelectListItem
                {
                    Value = n.doktorId.ToString(),
                    Text = n.doktorAdi.ToString()+" "+n.doktorSoyadi.ToString()
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
                return RedirectToAction("Success");
            }
            ViewBag.KlinikList = new SelectList(q.Klinikler.ToList(), "klinikId", "klinikAdi");
            TempData["msj"] = "Ekleme Başarısız";
            return View(l);
        }
    }
}
