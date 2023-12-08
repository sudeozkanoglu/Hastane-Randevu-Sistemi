using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;
using webProjeOdev.Models;

namespace webProjeOdev.ViewModels
{
    public class HastaneIletisimViewModel
    {
        public Hastane HastaneModel { get; set; }
        public IletisimBilgileri IletisimBilgileriModel { get; set; }
    }
}
