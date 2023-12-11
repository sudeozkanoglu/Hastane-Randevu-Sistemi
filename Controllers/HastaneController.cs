using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using webProjeOdev.Data;
using webProjeOdev.Models;
using Microsoft.EntityFrameworkCore;

namespace webProjeOdev.Controllers
{
    public class HastaneController : Controller
    {
        private HastaneRandevuContext h = new HastaneRandevuContext();
        public IActionResult Index()
        {
            var y = h.Hastaneler.ToList();
            var y1 = from Hastane in h.Hastaneler
                     select Hastane;
            return View(y);
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
    }
} 
