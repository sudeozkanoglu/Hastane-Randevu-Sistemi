using System.ComponentModel.DataAnnotations;

namespace webProjeOdev.Models
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
