using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using webProjeOdev.Data;
using webProjeOdev.Models;

namespace webProjeOdev.Controllers
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
            new AdminLogin(){
                KullaniciAdi="G201210004@sakarya.edu.tr",
                Sifre="sau",
                Ad="Sude",
                Soyad="Selvi",
                Id="1",
                Role="admin"
            },
            new AdminLogin(){
                KullaniciAdi="G201210034@sakarya.edu.tr", 
                Sifre="sau", 
                Ad="Sude", 
                Soyad="Özkanoğlu", 
                Id="2", 
                Role="admin"
            }
        };

        [HttpPost]
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
                        return View(a);
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
        [Authorize]
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
