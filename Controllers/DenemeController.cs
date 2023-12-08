using Microsoft.AspNetCore.Mvc;
using webProjeOdev.Data;
using webProjeOdev.ViewModels;

namespace webProjeOdev.Controllers
{
    public class DenemeController : Controller
    {
        private HastaneRandevuContext h = new HastaneRandevuContext();

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult HastaneEkle()
        {
            var viewModel = new HastaneIletisimViewModel
            {
                HastaneModel = new Models.Hastane(),
                IletisimBilgileriModel = new Models.IletisimBilgileri()
            };

            return View();
        }

        [HttpPost]
        public IActionResult HastaneEkle(HastaneIletisimViewModel hastaneIletisim)
        {
            ModelState.Remove(nameof(hastaneIletisim.HastaneModel.Hastalar));
            ModelState.Remove(nameof(hastaneIletisim.HastaneModel.Doktorlar));
            ModelState.Remove(nameof(hastaneIletisim.HastaneModel.Randevular));
            ModelState.Remove(nameof(hastaneIletisim.HastaneModel.HastaneKlinikler));
            ModelState.Remove(nameof(hastaneIletisim.HastaneModel.Klinikler));
            ModelState.Remove(nameof(hastaneIletisim.HastaneModel.HastaneAnaBilimler));
            ModelState.Remove(nameof(hastaneIletisim.HastaneModel.AnaBilimDallari));
            ModelState.Remove(nameof(hastaneIletisim.HastaneModel.HastanePoliklinikler));
            ModelState.Remove(nameof(hastaneIletisim.HastaneModel.Poliklinikler));
            ModelState.Remove(nameof(hastaneIletisim.IletisimBilgileriModel.Hastalar));
            ModelState.Remove(nameof(hastaneIletisim.IletisimBilgileriModel.Doktorlar));

            if (ModelState.IsValid)
            {
                var hastane = hastaneIletisim.HastaneModel;
                var iletisim = hastaneIletisim.IletisimBilgileriModel;

                h.Hastaneler.Add(hastane);
                h.IletisimBilgileri.Add(iletisim);
                h.SaveChanges();
                TempData["msj"] = "Ekleme Başarılı";
                return RedirectToAction("Index");
            }
            TempData["msj"] = "Ekleme Başarısız";
            return View(hastaneIletisim);
        }
    }
}
