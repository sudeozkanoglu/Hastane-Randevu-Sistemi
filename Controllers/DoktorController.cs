using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using webProjeOdev8.Data.Enum;
using webProjeOdev8.Models;
using WebProjeOdev8.Data;

namespace webProjeOdev8.Controllers
{
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
            List<SelectListItem> lstAnaBilimler = a.HastanedekiAnaBilimler
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
                Value="",
                Text="--Select ana bilim--"
            };
            lstAnaBilimler.Insert(0, defItem);
            return lstAnaBilimler;
        }
        public JsonResult GetAnaBilimByHastane(int hastaneId)
        {
            List<SelectListItem> anabilimler=GetAnaBilim(hastaneId);
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
                Text = "--Select klinik--"
            };
            lstKlinikler.Insert(0, defItem);
            return lstKlinikler;
        }
        public JsonResult GetKlinikByHastane(int hastaneId)
        {
            List<SelectListItem> klinikler = GetKlinik(hastaneId);
            return Json(klinikler);
        }

        //poliklinik yappppppppppppppppppppppppppppppppppppppppppppppppp
        private List<SelectListItem> GetPoliklinik(int klinikId)
        {
            List<SelectListItem> lstPoliklinikler = a.Poliklinikler
                .Where(c => c.klinikId == klinikId)
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
        public JsonResult GetPoliklinikByKlinik(int klinikId)
        {
            List<SelectListItem> poliklinikler = GetPoliklinik(klinikId);
            return Json(poliklinikler);
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
        
       

            [HttpPost]
        public IActionResult DoktorSil(int? id)
        {
            if (id == null)
            {
                TempData["hata"] = " Lütfen bos gecmeyiniz";
                return View("DoktorHata");
            }
            var d= a.Doktorlar.Include(x=>x.Randevular).FirstOrDefault(x=>x.doktorId==id);//Randevusu olan doktorlari listeler
            if (d == null)
            {
                TempData["hata"] = " Doktora ait kayit bulunamadi";
                return View("DoktorHata");
            }
            if(d.Randevular.Count()>0)
            {
                TempData["hata"] = " Doktora ait randevular var once randevulari iptal et";
                return View("DoktorHata");
            }
            a.Doktorlar.Remove(d);
            a.SaveChanges();
            TempData["hata"] = " Doktor silindi";
            return View("DoktorListele");
        }
    }
}
