﻿using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using webProjeOdev8.Models;
using WebProjeOdev8.Data;
using Microsoft.AspNetCore.Authorization;

namespace webProjeOdev8.Controllers
{
    public class GirisController : Controller
    {
        private HastaneRandevuContext _context = new HastaneRandevuContext();

        public IActionResult AdminLogin()
        {
            return View();
        }
        List<AdminLogin> admin = new List<AdminLogin>()
        {
            new AdminLogin(){KullaniciAdi="G201210004@sakarya.edu.tr",Sifre="sau",Ad="Sude",Soyad="Yalcin",Id="1",Role="admin"}
        };
        public IActionResult AdminLogin(AdminLogin a)
        {
            if (ModelState.IsValid)
            {
                foreach (var user in admin)
                {
                    if (user.KullaniciAdi == a.KullaniciAdi && user.Sifre == a.Sifre)
                    {

                        List<Claim> claims = new List<Claim>();
                        claims.Add(new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()));
                        claims.Add(new Claim(ClaimTypes.Name, user.Ad));
                        claims.Add(new Claim(ClaimTypes.Name, user.Soyad));
                        claims.Add(new Claim(ClaimTypes.Role, user.Role));
                        claims.Add(new Claim("KullaniciAdi", user.KullaniciAdi));

                        ClaimsIdentity identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                        ClaimsPrincipal principal = new ClaimsPrincipal(identity);
                        HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principal);
                        return RedirectToAction("Index", "AdminSayfasi");
                    }
                    else
                    {
                        return View(a);//HATA BASTIR SIFRE YANLIS DIYEEEEEEEEEEEEEEEE
                    }

                }
                TempData["hata"] = "Kullanici adi veya sifre hatali";
                return RedirectToAction("Index");
            }
            return View();
        }
        public IActionResult HastaGiris()
        {
            return View();
        }

        [HttpPost]
        public IActionResult HastaGiris(HastaGiris h)
        {
            var hasta = _context.Hastalar.ToList();
            if (ModelState.IsValid)
            {
                foreach (var userTc in hasta)
                {
                    if (userTc.hastaTC == h.tcHasta && userTc.hastaSifre == h.parola)
                    {
                        List<Claim> claims = new List<Claim>();
                        claims.Add(new Claim(ClaimTypes.NameIdentifier, userTc.hastaId.ToString()));
                        claims.Add(new Claim(ClaimTypes.Name, userTc.hastaAdi));
                        claims.Add(new Claim(ClaimTypes.Name, userTc.hastaSoyadi));
                        claims.Add(new Claim(ClaimTypes.Role, userTc.Role));
                        claims.Add(new Claim("KullaniciAdi", userTc.hastaTC));

                        ClaimsIdentity identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                        ClaimsPrincipal principal = new ClaimsPrincipal(identity);
                        HttpContext.Session.SetString("TCKimlikNo", userTc.hastaTC);
                        HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principal);
                        return RedirectToAction("RandevuEkle", "Randevu");
                    }
                   
                }

                TempData["hata"] = "Kullanici adi veya sifre hatali";
                return RedirectToAction("Index");
            }
            return View();
        }
        public IActionResult KayitOl()
        {
            return View();
        }

        [HttpPost]
        public IActionResult KayitOl(Hasta h)
        {

            ModelState.Remove(nameof(h.HastaneHastalar));
            ModelState.Remove(nameof(h.Randevular));
            ModelState.Remove(nameof(h.Hastaneler));


            if (ModelState.IsValid)
            {
                if (_context.Hastalar.Any(x => x.hastaTC == h.hastaTC))
                {
                    ModelState.AddModelError(nameof(h.hastaTC), "Hastanin üyeligi mevcut");
                   return View(h);
                }
                else
                {
                    _context.Hastalar.Add(h);
                    _context.SaveChanges();
                    return RedirectToAction("KayitListele");
                }
               
            }


            return View(h);
        }
        public IActionResult KayitListele()
        {
            var hastalar = _context.Hastalar.ToList();
            return View(hastalar);
        }
        [Authorize]
        public IActionResult AdminLogout()
        {
            HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction(nameof(AdminLogin));
        }
        public IActionResult GirisEngelle()
        {
            return View();
        }


    }
}
