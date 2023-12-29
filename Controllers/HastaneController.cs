using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using webProjeOdev.Data;
using webProjeOdev.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authorization;

namespace webProjeOdev.Controllers
{
    [Authorize]
    public class HastaneController : Controller
    {
        private HastaneRandevuContext h = new HastaneRandevuContext();
        public IActionResult Index()
        {
            var ha = h.Hastaneler.ToList();
            return View(ha);
        }

        public IActionResult Unsuccess()
        {
            return View();
        }
        public IActionResult HastaneEkle()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult HastaneEkle(Hastane ha)
        {

            ModelState.Remove(nameof(ha.Hastalar));
            ModelState.Remove(nameof(ha.Doktorlar));
            ModelState.Remove(nameof(ha.Randevular));
            ModelState.Remove(nameof(ha.HastaneAnaBilimler));
            ModelState.Remove(nameof(ha.AnaBilimDallari));
            ModelState.Remove(nameof(ha.HastaneKlinikler));
            ModelState.Remove(nameof(ha.Klinikler));
            ModelState.Remove(nameof(ha.HastanePoliklinikler));
            ModelState.Remove(nameof(ha.Poliklinikler));

            try
            {
                if (ModelState.IsValid)
                {
                    
                    h.Hastaneler.Add(ha);

                    // Tek bir SaveChanges çağrısı ile değişiklikleri kaydet
                    h.SaveChanges();

                    TempData["msj"] = "Ekleme Başarılı";
                    return RedirectToAction("Index");
                }
                TempData["msj"] = "Ekleme Başarısız - Geçersiz Model";
                return RedirectToAction("Unsuccess");
            }
            catch (Exception ex)
            {
                // Loglama yapabilir veya hata mesajını başka bir şekilde işleyebilirsiniz
                TempData["msj"] = "Ekleme Başarısız - Veritabanı Hatası";
                return RedirectToAction("Unsuccess");
            }
        }

        public IActionResult HastaneDuzenle(int? id)
        {
            if (id is null)
            {
                TempData["hata"] = "Lütfen boş geçmeyiniz";
                return View("Hata");
            }
            var ha = h.Hastaneler.FirstOrDefault(x => x.hastaneId == id);
            if (ha == null)
            {
                TempData["hata"] = "Lütfen geçerli bir yazar giriniz ";
                return View("Hata");

            }
            return View(ha);
        }

        [HttpPost]
        public IActionResult HastaneDuzenle(int? id, Hastane ha)
        {
            if (id != ha.hastaneId)
            {
                TempData["Hata"] = "Hatalıı";
                return View("Hata");
            }

            ModelState.Remove(nameof(ha.Hastalar));
            ModelState.Remove(nameof(ha.Doktorlar));
            ModelState.Remove(nameof(ha.Randevular));
            ModelState.Remove(nameof(ha.HastaneAnaBilimler));
            ModelState.Remove(nameof(ha.AnaBilimDallari));
            ModelState.Remove(nameof(ha.HastaneKlinikler));
            ModelState.Remove(nameof(ha.Klinikler));
            ModelState.Remove(nameof(ha.HastanePoliklinikler));
            ModelState.Remove(nameof(ha.Poliklinikler));

            if (ModelState.IsValid)
            {
                h.Hastaneler.Update(ha);
                h.SaveChanges();
                return RedirectToAction("Index");
            }
            TempData["Hata"] = "Hatalı";
            return View("Hata");
        }

        public IActionResult HastaneSil(int? id)//Hastaneyi sildigimde icinde hastaneyle ilgili bilgi olanlarin hepsini silebiliriz aslinda
        {
            if (id == null)
            {
                TempData["hata"] = " Lütfen bos gecmeyiniz";
                return View("HastaneHata");
            }
            var r = h.Hastaneler.Include(x => x.Randevular)
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
            var d = h.Hastaneler.Include(x => x.Doktorlar)
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
            h.Hastaneler.Remove(d);
            h.SaveChanges();
            TempData["hata"] = " Doktor silindi";
            return RedirectToAction("Index");
        }
        public IActionResult HastaneHata()
        {
            var y = h.Hastaneler.ToList();
            return View(y);
        }
    }
} 
