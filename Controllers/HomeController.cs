using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.Diagnostics;
using webProjeOdev.Models;
using webProjeSon.Services;

namespace webProjeOdev.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private  LanguageService _localizer;
        public HomeController(ILogger<HomeController> logger, LanguageService localizer)
        {
            _logger = logger;
            _localizer = localizer;
        }

        public IActionResult Index()
        {
            ViewBag.adminIndexFirst = _localizer.GetKey("adminIndexFirst").Value;
            ViewBag.hospital = _localizer.GetKey("hospital").Value;
            ViewBag.central = _localizer.GetKey("central").Value;
            ViewBag.adminpro = _localizer.GetKey("adminpro").Value;
            ViewBag.ana = _localizer.GetKey("ana").Value;
            ViewBag.adminIndexSecond = _localizer.GetKey("adminIndexSecond").Value;
            ViewBag.clinic = _localizer.GetKey("clinic").Value;
            ViewBag.klinik = _localizer.GetKey("klinik").Value;
            ViewBag.adminlogin = _localizer.GetKey("adminlogin").Value;
            ViewBag.adminlogout = _localizer.GetKey("adminlogout").Value;
            ViewBag.appointment = _localizer.GetKey("appointment").Value;
            ViewBag.header = _localizer.GetKey("header").Value;
            ViewBag.create = _localizer.GetKey("create").Value;
            ViewBag.home = _localizer.GetKey("home").Value;
            ViewBag.pol = _localizer.GetKey("pol").Value;
            ViewBag.poli = _localizer.GetKey("poli").Value;
            ViewBag.dok = _localizer.GetKey("dok").Value;
            ViewBag.doctor = _localizer.GetKey("doctor").Value;
            ViewBag.patient = _localizer.GetKey("patient").Value;
            ViewBag.pat = _localizer.GetKey("pat").Value;
            ViewBag.save = _localizer.GetKey("save").Value;
            ViewBag.majorUpdate = _localizer.GetKey("majorUpdate").Value;
            ViewBag.majorName = _localizer.GetKey("majorName").Value;
            ViewBag.back = _localizer.GetKey("back").Value;
            ViewBag.addMajor = _localizer.GetKey("addMajor").Value;
            ViewBag.edit = _localizer.GetKey("edit").Value;
            ViewBag.delete = _localizer.GetKey("delete").Value;
            ViewBag.addDoktor = _localizer.GetKey("addDoktor").Value;
            ViewBag.name = _localizer.GetKey("name").Value;
            ViewBag.surname = _localizer.GetKey("surname").Value;
            ViewBag.birth = _localizer.GetKey("birth").Value;
            ViewBag.gender = _localizer.GetKey("gender").Value;
            ViewBag.state = _localizer.GetKey("state").Value;
            ViewBag.phone = _localizer.GetKey("phone").Value;
            ViewBag.mail = _localizer.GetKey("mail").Value;
            ViewBag.city = _localizer.GetKey("city").Value;
            ViewBag.hospitalName = _localizer.GetKey("hospitalName").Value;
            ViewBag.clinicName = _localizer.GetKey("clinicName").Value;
            ViewBag.editDoc = _localizer.GetKey("editDoc").Value;
            ViewBag.workDay = _localizer.GetKey("workDay").Value;
            ViewBag.nameOfDays = _localizer.GetKey("nameOfDays").Value;
            ViewBag.identity = _localizer.GetKey("identity").Value;
            ViewBag.login = _localizer.GetKey("login").Value;
            ViewBag.addHospital = _localizer.GetKey("addHospital").Value;
            ViewBag.updateHospital = _localizer.GetKey("updateHospital").Value;
            ViewBag.userName = _localizer.GetKey("userName").Value;
            ViewBag.password = _localizer.GetKey("password").Value;
            ViewBag.addClinic = _localizer.GetKey("addClinic").Value;
            ViewBag.addPoli = _localizer.GetKey("addPoli").Value;
            ViewBag.poliName = _localizer.GetKey("poliName").Value;
            ViewBag.editClinic = _localizer.GetKey("editClinic").Value;
            ViewBag.ana2 = _localizer.GetKey("ana2").Value;
            ViewBag.anaReg = _localizer.GetKey("anaReg").Value;
            ViewBag.otherAna = _localizer.GetKey("otherAna").Value;
            ViewBag.docName = _localizer.GetKey("docName").Value;
            ViewBag.editPol = _localizer.GetKey("editPol").Value;
            ViewBag.docProcedure = _localizer.GetKey("docProcedure").Value;
            ViewBag.docAddProcedure = _localizer.GetKey("docAddProcedure").Value;
            ViewBag.docIcerik = _localizer.GetKey("docIcerik").Value;
            ViewBag.docDiger = _localizer.GetKey("docDiger").Value;
            ViewBag.addHospitall = _localizer.GetKey("addHospitall").Value;
            ViewBag.otherHospital = _localizer.GetKey("otherHospital").Value;
            ViewBag.hosText = _localizer.GetKey("hosText").Value;
            ViewBag.textHos = _localizer.GetKey("textHos").Value;
            ViewBag.textAna = _localizer.GetKey("textAna").Value;
            ViewBag.textClinic = _localizer.GetKey("textClinic").Value;
            ViewBag.textPol = _localizer.GetKey("textPol").Value;
            ViewBag.addingPol = _localizer.GetKey("addingPol").Value;
            ViewBag.otherPolPro = _localizer.GetKey("otherPolPro").Value;
            ViewBag.polText = _localizer.GetKey("polText").Value;
            ViewBag.poliText = _localizer.GetKey("poliText").Value;
            ViewBag.addingCli = _localizer.GetKey("addingCli").Value;
            ViewBag.otherCliPro = _localizer.GetKey("otherCliPro").Value;
            ViewBag.textCli = _localizer.GetKey("textCli").Value;
            ViewBag.cliText = _localizer.GetKey("cliText").Value;
            ViewBag.userIndexFirst = _localizer.GetKey("userIndexFirst").Value;
            ViewBag.listAppointment = _localizer.GetKey("listAppointment").Value;
            ViewBag.otherAppointment = _localizer.GetKey("otherAppointment").Value;
            var currentCulture = Thread.CurrentThread.CurrentCulture.Name;
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult ChangeLanguage(string culture)
        {
            Response.Cookies.Append(CookieRequestCultureProvider.DefaultCookieName,
                CookieRequestCultureProvider.MakeCookieValue(new RequestCulture(culture)),
                new CookieOptions() { 
                    Expires = DateTimeOffset.UtcNow.AddYears(1) 
                });
            return Redirect(Request.Headers["Referer"].ToString());
        }
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}