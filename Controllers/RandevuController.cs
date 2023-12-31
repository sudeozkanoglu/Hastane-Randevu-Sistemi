using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
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
            string hastaTcCookie = HttpContext.Session.GetString("TCKimlikNo");

            var hastatc = a.Randevular.Where(a=>a.Hasta.hastaTC==hastaTcCookie).ToList();
            var y = a.Randevular.Include(a => a.AnaBilimDali).Include(a => a.Hastane).Include(a => a.Klinik).Include(a => a.Poliklinik).Include(a => a.Doktor).Include(a => a.Hasta).Where(a=>a.Hasta.hastaTC== hastaTcCookie).ToList();
            
            return View(y);
        }
        private List<SelectListItem> GetDoktor(int hastaneId, int klinikId)
        {
            List<SelectListItem> lstDoktorlar = a.Doktorlar
                .Where(c => c.hastaneId == hastaneId)
                .Where(c => c.klinikId == klinikId)
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
        public JsonResult GetDoktorByHastaneAndKlinik(int hastaneId, int klinikId)
        {
            List<SelectListItem> doktorlar = GetDoktor(hastaneId, klinikId);
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

            if (haftaninGunu == DayOfWeek.Saturday || haftaninGunu == DayOfWeek.Sunday)
            {
                TempData["hata"] = "Cumartesi ve pazar secilemez";
                return RedirectToAction("RandevuEkle");
            }
            //doktor pazartesi ve sali calisiyor diyelim. Doktordan sali günü icin randevu aldigimda asagidaki foreeache'e ilk giriyor sonra if'e giriyor pazartesi ile sali uyusmadigi icin doktor payartesi gunu calisiyor hata mesajini veriyor 
            /*   var doktorCalismaGünler = a.DoktorCalismaGunler.Include(a=>a.CalismaGunleri).Where(a=>a.doktorId==r.doktorId).ToList();
               foreach (var item in doktorCalismaGünler)
               {
                   if(item.doktorId==r.doktorId&&item.CalismaGunleri.calismaGunleri!= r.randevuTarihi.ToString())
                   {
                       string calgun = "";
                       foreach (var a in doktorCalismaGünler)
                       {
                           calgun += a.CalismaGunleri.calismaGunleri + " ";
                       }
                        TempData["hata"] = "Doktor "+ calgun + " günleri calismakta. Lütfen sadece o günleri seciniz.";
                       return RedirectToAction("RandevuEkle");
                   }

               }
            */
            var ran = a.Randevular.Where(a => a.randevuTarihi == r.randevuTarihi && a.randevuSaat == r.randevuSaat && a.doktorId == r.doktorId).ToList();
            if (ran.Count() > 0)
            {
                TempData["hata"] = "O gün ve saat dolu. Lütfen baska bir gün veya saat seciniz.";
                return RedirectToAction("RandevuEkle");
            }
            ModelState.Remove(nameof(r.Hastane));
            ModelState.Remove(nameof(r.AnaBilimDali));
            ModelState.Remove(nameof(r.Klinik));
            ModelState.Remove(nameof(r.Poliklinik));
            ModelState.Remove(nameof(r.Doktor));
            ModelState.Remove(nameof(r.Hasta));

            if (ModelState.IsValid)
            {
                //Buraya hastanin id'sini atamaliyiz
                string hastaTcCookie = HttpContext.Session.GetString("TCKimlikNo");
           
                    var hastaidList = a.Hastalar
                        .Where(a => a.hastaTC == hastaTcCookie)
                        .Select(a => a.hastaId)
                        .ToList();
                         var randevu = new Randevu
                         {
                             randevuTarihi = r.randevuTarihi,
                             randevuSaat = r.randevuSaat,
                             hastaneId = r.hastaneId,
                             anaBilimDaliId = r.anaBilimDaliId,
                             klinikId = r.klinikId,
                             poliklinikId = r.poliklinikId,
                             doktorId = r.doktorId,
                             hastaId = hastaidList.FirstOrDefault()

                         };
                         a.Randevular.Add(randevu);
                         a.SaveChanges();
                         TempData["basarili"] = "Randevunuz olusturuldu";
                         return RedirectToAction("Listele");
               
                   
              
            }

            return RedirectToAction("RandevuEkle");
        }

        public IActionResult RandevuSil(int? id)
        {

            var d = a.Randevular.FirstOrDefault(x => x.doktorId == id);

            a.Randevular.Remove(d);
            a.SaveChanges();
            TempData["hata"] = " Randevunuz silindi";
            return RedirectToAction("RandevuEkle");
        }
    }
}
