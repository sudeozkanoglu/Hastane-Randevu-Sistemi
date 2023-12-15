using System.ComponentModel.DataAnnotations;
using webProjeOdev2.Data.Enum;

namespace webProjeOdev2.Models
{
    public class Hastane
    {
        [Key]
        public int hastaneId { get; set; }

        [Required]
        [MaxLength(100)]
        [Display(Name = "Hastane Adı")]
        public string hastaneAdi { get; set; }
        [Required]
        [Phone]
        [Display(Name = "Telefon Numarası")]
        public string telefonNumarasi { get; set; }

        [Required]
        [EmailAddress]
        [Display(Name = "E-mail Adresi")]
        public string email { get; set; }

        [Required]
        [Display(Name = "İl")]
        public Il Iller { get; set; }

        //**************************************************************************

        public ICollection<Doktor> Doktorlar { get; set; }

        public ICollection<Randevu> Randevular { get; set; }

        //********************************************************
        //Çok a çok ilişki kısmı - HastaneHasta
        public List<HastaneHasta> HastaneHastalar { get; } = new();
        public List<Hasta> Hastalar { get; } = new();

        //********************************************************
        //Çok a çok ilişki kısmı - HastaneAnaBilimDali
        public List<HastaneAnaBilim> HastaneAnaBilimler { get; } = new();
        public List<AnaBilimDali> AnaBilimDallari { get; } = new();

        //********************************************************
        //Çok a çok ilişki kısmı - HastaneKlinik
        public List<HastaneKlinik> HastaneKlinikler { get; } = new();
        public List<Klinik> Klinikler { get; } = new();

        //********************************************************
        //Çok a çok ilişki kısmı - HastanePoliklinik
        public List<HastanePoliklinik> HastanePoliklinikler { get; } = new();
        public List<Poliklinik> Poliklinikler { get; } = new();


    }
}
