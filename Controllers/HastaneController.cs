using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using webProjeOdev.Data;
using webProjeOdev.Models;
using webProjeOdev.Data.Enum;
using webProjeOdev.ViewModels;
using Microsoft.EntityFrameworkCore;

namespace webProjeOdev.Controllers
{
    public class HastaneController : Controller
    {
        private HastaneRandevuContext h = new HastaneRandevuContext();
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Unsuccess()
        {
            return View();
        }
        public IActionResult HastaneEkle()
        {
            var viewModel = new HastaneIletisimViewModel
            {
                HastaneModel = new Hastane(),
                IletisimBilgileriModel = new IletisimBilgileri(),
                /*HastaneAnaBilimModel = new HastaneAnaBilim(),
                HastaneKlinikModel = new HastaneKlinik(),
                HastanePoliklinikModel = new HastanePoliklinik(),

                AnaBilimDallari = h.AnaBilimDallari
                .Select(abd => new SelectListItem
                {
                    Value = abd.anaBilimDaliId.ToString(),
                    Text = abd.anaBilimDaliAdi
                })
                .ToList(),

                Klinikler = Enumerable.Empty<SelectListItem>()*/
            };

            return View();
        }

        /*[HttpPost]
        public IActionResult KlinikleriGetir(int seciliAnaBilim)
        {
            var klinikler = h.Klinikler
                .Where(x => x.anaBilimDaliId == seciliAnaBilim)
                .Select(x => new SelectListItem
                {
                    Value = x.klinikId.ToString(),
                    Text = x.klinikAdi
                })
                .ToList();
            return Json(klinikler);
        }

        [HttpPost]
        public IActionResult PoliklinikleriGetir(int seciliKlinik)
        {
            var poliklinikler = h.Poliklinikler
                .Where(v => v.klinikId == seciliKlinik)
                .Select(v => new SelectListItem
                {
                    Value = v.poliklinikId.ToString(),
                    Text = v.poliklinikAdi
                })
                .ToList();
            return Json(poliklinikler);
        }
        */
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult HastaneEkle(HastaneIletisimViewModel viewModel)
        {

            ModelState.Remove(nameof(viewModel.HastaneModel.Hastalar));
            ModelState.Remove(nameof(viewModel.HastaneModel.Doktorlar));
            ModelState.Remove(nameof(viewModel.HastaneModel.Randevular));
            ModelState.Remove(nameof(viewModel.HastaneModel.HastaneKlinikler));
            ModelState.Remove(nameof(viewModel.HastaneModel.Klinikler));
            ModelState.Remove(nameof(viewModel.HastaneModel.HastaneAnaBilimler));
            ModelState.Remove(nameof(viewModel.HastaneModel.AnaBilimDallari));
            ModelState.Remove(nameof(viewModel.HastaneModel.HastanePoliklinikler));
            ModelState.Remove(nameof(viewModel.HastaneModel.Poliklinikler));
            if (ModelState.IsValid)
            {
               var hastane = viewModel.HastaneModel;
               var iletisim = viewModel.IletisimBilgileriModel;

               h.Hastaneler.Add(hastane);
               h.IletisimBilgileri.Add(iletisim);
               h.SaveChanges();
               TempData["msj"] = "Ekleme Başarılı";
               return RedirectToAction("Index");
            }
            TempData["msj"] = "Ekleme Başarısız";
            return RedirectToAction("Unsuccess");
        }
    }
} 
