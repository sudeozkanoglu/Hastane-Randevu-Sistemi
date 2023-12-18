using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using webProjeOdev8.Models;
using WebProjeOdev8.Data;

namespace webProjeOdev8.Controllers
{
    public class HastaneAnaBilimController : Controller
    {
        private HastaneRandevuContext s = new HastaneRandevuContext();

        public IActionResult HastaneAnaBilimEkle()
        {
            ViewBag.HastaneList = new SelectList(s.Hastaneler.ToList(), "hastaneId", "hastaneAdi");
            ViewBag.AnaBilimList = new SelectList(s.AnaBilimDallari.ToList(), "anaBilimDaliId", "anaBilimDaliAdi");

            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult HastaneAnaBilimEkle(HastaneAnaBilim hab)
        {
            ModelState.Remove(nameof(hab.Hastane));
            ModelState.Remove(nameof(hab.AnaBilimDali));
            if (ModelState.IsValid)
            {
                s.HastanedekiAnaBilimler.Add(hab);
                s.SaveChanges();
                return RedirectToAction("Success");
            }
            return View();
        }

        public IActionResult Success()
        {
            return View();
        }
    }
}
