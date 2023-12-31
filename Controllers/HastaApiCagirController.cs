using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using webProjeOdev8.Models;

namespace webProjeOdev8.Controllers
{
    public class HastaApiCagirController : Controller
    {
        public async Task<IActionResult> Index()
        {
            List<Hasta> hastalar = new List<Hasta>();
            HttpClient client = new HttpClient();
            var response = await client.GetAsync("https://localhost:7176/api/HastaApi");
            var jsonResponse = await response.Content.ReadAsStringAsync();
            hastalar = JsonConvert.DeserializeObject<List<Hasta>>(jsonResponse);


            return View(hastalar);
        }
        public async Task<IActionResult> Delete(int id)
        {
            HttpClient client = new HttpClient();
            var response = await client.DeleteAsync($"https://localhost:7176/api/HastaApi/{id}");

            if (response.IsSuccessStatusCode)
            {
                // Silme başarılı ise, tekrar hastaları listele
                return RedirectToAction("Index");
            }
            else
            {
                // Silme başarısız ise, hata mesajını göster
                var errorResponse = await response.Content.ReadAsStringAsync();
                TempData["ErrorMessage"] = errorResponse; // TempData, bir request ömrü boyunca geçerli olan bir veri saklama mekanizmasıdır
                return RedirectToAction("Index");
            }
        }
    }
}

