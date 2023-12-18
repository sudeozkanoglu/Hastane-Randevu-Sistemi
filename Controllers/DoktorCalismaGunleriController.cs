using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.SignalR;
using webProjeOdev8.Models;
using WebProjeOdev8.Data;

namespace webProjeOdev8.Controllers
{
    public class DoktorCalismaGunleriController : Controller
    {
        private HastaneRandevuContext s = new HastaneRandevuContext();

        public IActionResult Index()
        {
           
            return View();
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
                return View();
            }
            return View(dcg);
        }
    }
}
