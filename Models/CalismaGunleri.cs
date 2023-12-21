using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using webProjeOdev8.Data.Enum;
using webProjeOdev8.Models;
using NuGet.Packaging.Signing;

namespace webProjeOdev8.Models
{
    public class CalismaGunleri
    {
        [Key]
        public int calismaGunleriId { get; set; }

        [Required]
        [Display(Name = "Çalışma Günleri")]
        public string calismaGunleri { get; set; }

        [Required]
        [Display(Name = "Baslama Saati")]
        public TimeSpan baslamaSaati { get; set; }
        [Required]
        [Display(Name = "Bitis Saati")]
        public TimeSpan bitisSaati { get; set; }

        //Coka Cok kismi************************************************
        public List<DoktorCalismaGunleri> DoktorCalismaGunleri { get; } = new();

    }
}

